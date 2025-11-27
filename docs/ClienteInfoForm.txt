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
    public partial class ClienteInfoForm : Form
    {

        string data_source = "datasource=localhost;username=root;password=;database=tripagency";

        public ClienteInfoForm(int clienteId)
        {
            InitializeComponent();
            CarregarDadosDoCliente(clienteId);
        }

        private void CarregarDadosDoCliente(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = @"SELECT * FROM clientes WHERE Id_Cliente = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", clienteId);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    labelNome.Text = reader["Nome"].ToString();
                    labelPassaporte.Text = reader["Numero_de_Passaporte"].ToString();
                    labelBI.Text = reader["Numero_do_BI"].ToString();
                    labelNacionalidade.Text = reader["Nacionalidade"].ToString();
                    labelGenero.Text = reader["Genero"].ToString();
                    labelNascimento.Text = Convert.ToDateTime(reader["Data_de_Nascimento"]).ToString("dd/MM/yyyy");
                    labelEndereco.Text = reader["Endereco"].ToString();
                    labelTelefone.Text = reader["Telefone"].ToString();
                    labelEmail.Text = reader["Email"].ToString();
                    labelCadastro.Text = Convert.ToDateTime(reader["Data_Cadastro"]).ToString("dd/MM/yyyy HH:mm");
                }

                reader.Close();
            }
        }
    }
}
    

