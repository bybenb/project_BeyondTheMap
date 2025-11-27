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
    public partial class AdminLoginForm : Form
    {

        string data_source = "datasource=localhost;username=root;password=;database=tripagency";

        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = adminName.Text.Trim();
            string senha = adminPassword.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM administradores WHERE username = @username AND senha = @senha;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);

                int resultado = Convert.ToInt32(cmd.ExecuteScalar());

                if (resultado > 0)
                {
                    MessageBox.Show("Login realizado com sucesso!");

                    this.Hide();
                    AdminMenuForm formPrincipal = new AdminMenuForm();
                    formPrincipal.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
