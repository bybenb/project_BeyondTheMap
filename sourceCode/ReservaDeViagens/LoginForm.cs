using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

using MySql.Data.MySqlClient;



namespace ReservaDeViagens
{
    public partial class LoginForm : Form
    {
        string data_source = "datasource=localhost;username=root;password=;database=tripagency";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {

            string usuario = txtUsername.Text.Trim();
            string senha = txtSenha.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();

                // Primeiro verificar se o usuário existe na tabela funcionarios
                string queryFuncionario = "SELECT id FROM funcionarios WHERE Username = @username AND Senha = @senha;";
                MySqlCommand cmd = new MySqlCommand(queryFuncionario, conn);
                cmd.Parameters.AddWithValue("@username", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);

                object resultFuncionario = cmd.ExecuteScalar();

                // Agora verifica se é administrador
                string queryAdm = "SELECT id FROM administradores WHERE username = @username AND senha = @senha;";
                MySqlCommand cmdAdm = new MySqlCommand(queryAdm, conn);
                cmdAdm.Parameters.AddWithValue("@username", usuario);
                cmdAdm.Parameters.AddWithValue("@senha", senha);

                object resultAdm = cmdAdm.ExecuteScalar();

                if (resultFuncionario != null) // é funcionário
                {
                    int funcionarioId = Convert.ToInt32(resultFuncionario);

                    // REGISTRA LOGIN com o funcionario_id
                    string insertLog = "INSERT INTO log_acessos (funcionario_id, username, data_login) VALUES (@funcionario_id, @username, NOW());";
                    MySqlCommand logCmd = new MySqlCommand(insertLog, conn);
                    logCmd.Parameters.AddWithValue("@funcionario_id", funcionarioId);
                    logCmd.Parameters.AddWithValue("@username", usuario);
                    logCmd.ExecuteNonQuery();

                    MessageBox.Show("Login realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abre o MenuForm e passa o username e o funcionario_id
                    MenuForm formPrincipal = new MenuForm(usuario);
                    formPrincipal.Show();
                    this.Hide();
                }
                else if (resultAdm != null) // é administrador
                {
                    MessageBox.Show("Login de administrador realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MenuForm formPrincipal = new MenuForm(usuario);
                    formPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult fechar = MessageBox.Show("Deseja sair do sistema?", "Sair?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (fechar == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LerRostoForm formPrincipal = new LerRostoForm();
            formPrincipal.Show();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
