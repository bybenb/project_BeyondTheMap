using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

namespace ReservaDeViagens
{
    public partial class LerRostoForm : Form
    {
        private VideoCapture capture;
        private CascadeClassifier faceDetector;
        private bool capturando = false;
        private Mat currentFrame;

        private LBPHFaceRecognizer reconhecedor;
        private List<Mat> rostosTreinados = new List<Mat>();
        private List<int> labels = new List<int>();
        private Dictionary<int, string> nomesFuncionarios = new Dictionary<int, string>();

        private int funcionarioAtualId = -1; // Guarda ID do funcionário reconhecido
        private int idLogAtual = -1; // Guarda o ID do log inserido
        string data_source = "datasource=localhost;username=root;password=;database=tripagency";

        public LerRostoForm()
        {
            InitializeComponent();
        }

        private void LerRostoForm_Load(object sender, EventArgs e)
        {
            try
            {
                string exeFolder = Application.StartupPath;
                string xmlPath = Path.Combine(exeFolder, "Resources", "haarcascade_frontalface_default.xml");
                if (!File.Exists(xmlPath))
                    xmlPath = Path.Combine(exeFolder, "haarcascade_frontalface_default.xml");

                if (!File.Exists(xmlPath))
                {
                    MessageBox.Show("Arquivo haarcascade_frontalface_default.xml não encontrado!");
                    this.Close();
                    return;
                }

                faceDetector = new CascadeClassifier(xmlPath);
                CarregarRostosDoBanco();

                if (rostosTreinados.Count == 0)
                {
                    btnIniciar.Enabled = false;
                    MessageBox.Show("Nenhum rosto cadastrado. O reconhecimento não funcionará.");
                }


                if (rostosTreinados.Count > 0)
                {
                    reconhecedor = new LBPHFaceRecognizer(1, 8, 8, 8, 80);

                    VectorOfMat rostosVM = new VectorOfMat();
                    foreach (var rosto in rostosTreinados)
                        rostosVM.Push(rosto);

                    Mat labelsMat = new Mat(labels.Count, 1, DepthType.Cv32S, 1);
                    int[] labelsArray = labels.ToArray();
                    labelsMat.SetTo<int>(labelsArray);

                    reconhecedor.Train(rostosVM, labelsMat);
                   // labelReconhecido.Text = $"Total= {rostosTreinados.Count} rosto(s)";
                }
                else
                {
                    labelReconhecido.Text = "Nenhum rosto cadastrado encontrado.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inicializar: " + ex.Message);
            }
        }

        private void CarregarRostosDoBanco()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(data_source))
                {
                    conn.Open();
                    string query = "SELECT rf.FuncionarioId, rf.RostoLbp, f.Nome " +
                                   "FROM RostoFuncionario rf JOIN funcionarios f ON rf.FuncionarioId=f.Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32("FuncionarioId");
                        string nome = reader.GetString("Nome");
                        nomesFuncionarios[id] = nome;

                        byte[] bytes = (byte[])reader["RostoLbp"];
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            Bitmap bmp = new Bitmap(ms);
                            Mat matColor = BitmapToMat(bmp);
                            Mat matGray = new Mat();
                            CvInvoke.CvtColor(matColor, matGray, ColorConversion.Bgr2Gray);

                            rostosTreinados.Add(matGray);
                            labels.Add(id);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar rostos do banco: " + ex.Message);
            }
        }

        private Mat BitmapToMat(Bitmap bmp)
        {
            return bmp.ToImage<Bgr, byte>().Mat;
        }

        private void ProcessarFrame(object sender, EventArgs e)
        {
            currentFrame = capture?.QueryFrame();
            if (currentFrame == null) return;

            using (var imageFrame = currentFrame.ToImage<Bgr, byte>())
            {
                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = faceDetector.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                foreach (var face in faces)
                {
                    imageFrame.Draw(face, new Bgr(Color.Green), 2);
                    Mat faceMat = grayFrame.Copy(face).Mat;
                    var result = reconhecedor.Predict(faceMat);

                    string texto = "Desconhecido";
                    if (result.Label != -1 && result.Distance < 60)
                    {
                        funcionarioAtualId = result.Label;
                        texto = nomesFuncionarios.ContainsKey(result.Label)
                            ? nomesFuncionarios[result.Label]
                            : "Desconhecido";

                        labelReconhecido.Text = $"Reconhecido: {texto}";

                        RegistrarLogin(funcionarioAtualId); // <<< REGISTRA LOGIN NO BANCO

                        Application.Idle -= ProcessarFrame;
                        capture.Stop();
                        capturando = false;

                        this.Invoke(new Action(() =>
                        {
                            MenuForm wf = new MenuForm(funcionarioAtualId, idLogAtual); // passa dados
                            wf.Show();
                            this.Close();
                        }));

                        return;
                    }
                    else
                    {
                        labelReconhecido.Text = "Desconhecido";
                    }
                }

                pictureBoxCamera.Image = imageFrame.ToBitmap();
            }
        }

        private void RegistrarLogin(int funcionarioId)
        {
            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string insert = @"
                                INSERT INTO log_acessos (funcionario_id, username, data_login)
                                VALUES (@id, (SELECT Username FROM funcionarios WHERE id = @id), NOW());
                                SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@id", funcionarioId);

                // guarda o ID do log atual (para atualizar o logout depois)
                idLogAtual = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        private void LerRostoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (capture != null)
            {
                Application.Idle -= ProcessarFrame;
                capture.Stop();
                capture.Dispose();
            }
        }

        private void btnSenha_Click(object sender, EventArgs e)
        {
            LoginForm novoForm = new LoginForm();
            novoForm.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult fechar = MessageBox.Show("Deseja sair do sistema?", "Sair?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (fechar == DialogResult.Yes)
                Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            InicioForm formPrincipal = new InicioForm();
            formPrincipal.Show();
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!capturando)
                {
                    capture = new VideoCapture(0);
                    Application.Idle += ProcessarFrame;
                    capturando = true;
                    labelReconhecido.Text = "Câmera iniciada!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar câmera: " + ex.Message);
            }
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            PararCaptura();
        }

        private void PararCaptura()
        {
            if (capturando)
            {
                Application.Idle -= ProcessarFrame;
                capture.Stop();
                capture.Dispose();
                capture = null;
                capturando = false;
                pictureBoxCamera.Image = null;
                labelReconhecido.Text = "Captura parada.";
            }
        }


    }
}
