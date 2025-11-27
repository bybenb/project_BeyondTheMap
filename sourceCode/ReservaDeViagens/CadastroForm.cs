using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace ReservaDeViagens
{
    public partial class CadastroForm : Form
    {
        MySqlConnection Conexao;

        public CadastroForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

          

            DateTime dataSelecionada = dataNasc.Value.Date;



            try
            {
                string data_source = "datasource=localhost;username=root;password=;database=tripagency";
               
                Conexao = new MySqlConnection(data_source);

                using (MySqlConnection conn = new MySqlConnection(data_source))
                {
                    conn.Open();
                    string query = "INSERT INTO Clientes (Nome, Numero_de_Passaporte, Numero_do_BI, Nacionalidade, Genero, Endereco, Telefone, Email, Data_de_Nascimento) " +
                                   "VALUES (@nome, @passaporte, @bi, @nacionalidade, @genero, @endereco, @telefone, @email, @data);";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@passaporte", txtPassaporte.Text);
                    cmd.Parameters.AddWithValue("@bi", txtBI.Text);
                    cmd.Parameters.AddWithValue("@nacionalidade", txtNacionalidade.Text);
                    cmd.Parameters.AddWithValue("@genero", comboGenero.Text);
                    cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@data", dataSelecionada);

                    cmd.ExecuteNonQuery();
                    int clienteId = (int)cmd.LastInsertedId;

                    MessageBox.Show("SALVO!");

                    ViagemForm novoForm = new ViagemForm(clienteId);
                    this.Hide();
                    novoForm.ShowDialog();
                    this.Show();

                }

            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);           
            } finally
            {
                Conexao.Close();
            }



            
        }

        private void CadastroForm_Load(object sender, EventArgs e)
        {

        }
    }
}
