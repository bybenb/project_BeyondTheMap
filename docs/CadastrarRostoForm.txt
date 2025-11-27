using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using MySql.Data.MySqlClient;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace ReservaDeViagens
{
    public partial class CadastrarRostoForm : Form
    {
        private int funcionarioId;
        private string funcionarioNome;

        private VideoCapture capture;
        private CascadeClassifier faceDetector;
        private bool capturando = false;
        private Mat currentFrame;

        string data_source = "datasource=localhost;username=root;password=;database=tripagency";

        public CadastrarRostoForm(int id, string nome)
        {
            InitializeComponent();
            funcionarioId = id;
            funcionarioNome = nome;
            labelFuncionario.Text = $"Funcionário: {nome} (ID: {id})";
        }

        private void CadastrarRostoForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Caminho completo para a pasta Resources dentro da pasta do exe
                string exeFolder = Application.StartupPath; // bin\Debug ou bin\Release
                string xmlPath = Path.Combine(exeFolder, "Resources", "haarcascade_frontalface_default.xml");

                if (!File.Exists(xmlPath))
                {
                    MessageBox.Show("Arquivo haarcascade_frontalface_default.xml não encontrado em:\n" + xmlPath);
                    this.Close();
                    return;
                }

                faceDetector = new CascadeClassifier(xmlPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar XML de detecção de rosto: " + ex.Message);
                this.Close();
            }
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
                    MessageBox.Show("Captura iniciada!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar a câmera: " + ex.Message);
            }
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            try
            {
                if (capturando && capture != null)
                {
                    Application.Idle -= ProcessarFrame;
                    capture.Stop();
                    capture.Dispose();
                    capture = null;
                    capturando = false;

                    if (pictureBoxCamera.Image != null)
                    {
                        pictureBoxCamera.Image.Dispose();
                        pictureBoxCamera.Image = null;
                    }

                    MessageBox.Show("Captura parada!");
                }
                else
                {
                    MessageBox.Show("A captura já está parada.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao parar a câmera: " + ex.Message);
            }
        }

        private void ProcessarFrame(object sender, EventArgs e)
        {
            currentFrame = capture?.QueryFrame();
            if (currentFrame != null)
            {
                using (var imageFrame = currentFrame.ToImage<Bgr, byte>())
                {
                    var grayFrame = imageFrame.Convert<Gray, byte>();
                    var faces = faceDetector.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                    foreach (var face in faces)
                    {
                        imageFrame.Draw(face, new Bgr(Color.Green), 2);
                    }

                    pictureBoxCamera.Image = imageFrame.ToBitmap();
                }
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (currentFrame == null)
            {
                MessageBox.Show("Inicie a câmera primeiro!");
                return;
            }

            using (var imageFrame = currentFrame.ToImage<Bgr, byte>())
            {
                var grayFrame = imageFrame.Convert<Gray, byte>();
                var faces = faceDetector.DetectMultiScale(grayFrame, 1.1, 10, Size.Empty);

                if (faces.Length > 0)
                {
                    // Captura apenas o primeiro rosto detectado
                    var faceImg = grayFrame.Copy(faces[0]);

                    // Salva na base de dados
                    using (MemoryStream ms = new MemoryStream())
                    {
                        faceImg.ToBitmap().Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] bytes = ms.ToArray();

                        using (MySqlConnection conn = new MySqlConnection(data_source))
                        {
                            conn.Open();
                            string query = "INSERT INTO RostoFuncionario (FuncionarioId, RostoLbp) VALUES (@id, @rosto)";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", funcionarioId);
                            cmd.Parameters.Add("@rosto", MySqlDbType.LongBlob).Value = bytes;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Rosto cadastrado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Nenhum rosto detectado. Tente novamente.");
                }
            }
        }

        private void CadastrarRostoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (capture != null)
            {
                Application.Idle -= ProcessarFrame;
                capture.Stop();
                capture.Dispose();
            }
        }
    }
}
