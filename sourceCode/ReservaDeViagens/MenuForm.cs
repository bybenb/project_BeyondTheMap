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
    public partial class MenuForm : Form
    {

        string data_source = "datasource=localhost;username=root;password=;database=tripagency";
        private string usuarioLogado; // guarda o username do login

        // Novo construtor que recebe o usuário logado
        public MenuForm(string usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
        }

        // Construtor antigo (mantido caso precises abrir o form de outra forma)
        public MenuForm()
        {
            InitializeComponent();
        }

        private void verReserva_Click(object sender, EventArgs e)
        {
            verReservaForm novoForm = new verReservaForm();
            this.Hide();
            novoForm.ShowDialog();
            this.Show();
        }

        private void fazerReserva_Click(object sender, EventArgs e)
        {
            DialogResult fechar;

            fechar = MessageBox.Show("É um cidadão estrangeiro?", "Fazer reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (fechar == DialogResult.Yes)
            {
                Cadastro2Form novoForm = new Cadastro2Form();
                this.Hide();
                novoForm.ShowDialog();
                this.Show();
            }
            else if (fechar == DialogResult.No)
            {
                CadastroForm novoForm = new CadastroForm();
                this.Hide();
                novoForm.ShowDialog();
                this.Show();
            }
        }

        private void welcomeForm_Load(object sender, EventArgs e)
        {
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            AdminLoginForm novoForm = new AdminLoginForm();
            this.Hide();
            novoForm.ShowDialog();
            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            menuOff.Show(btnClose, 0, btnClose.Height);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            // ✅ Registrar logout antes de voltar ao início
            RegistrarLogout();
            registrarlogoutFACE();

            InicioForm formPrincipal = new InicioForm();
            formPrincipal.Show();
            this.Close();
        }

        private void Sair_Click(object sender, EventArgs e)
        {
            DialogResult fechar;

            fechar = MessageBox.Show("Deseja sair do sistema?", "Sair?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (fechar == DialogResult.Yes)
            {
                // ✅ Registrar logout antes de sair
                RegistrarLogout();
                registrarlogoutFACE();

                this.Close();
                Application.Exit();
            }
        }

        // ✅ Método para registrar logout no banco
        private void RegistrarLogout()
        {
            if (string.IsNullOrEmpty(usuarioLogado)) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(data_source))
                {
                    conn.Open();
                    string update = @"
                        UPDATE log_acessos 
                        SET data_logout = NOW() 
                        WHERE username = @username 
                        ORDER BY id DESC 
                        LIMIT 1;";

                    MySqlCommand cmd = new MySqlCommand(update, conn);
                    cmd.Parameters.AddWithValue("@username", usuarioLogado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar logout: " + ex.Message);
            }
        }

        private void registrarlogoutFACE()
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(data_source))
                {
                    conn.Open();

                    string query = "";

                    // 🔹 Caso tenha vindo do login facial (com logId)
                    if (logId > 0)
                    {
                        query = "UPDATE log_acessos SET data_logout = NOW() WHERE id = @logId;";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@logId", logId);
                        cmd.ExecuteNonQuery();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar logout: " + ex.Message);
            }

        }

        // ✅ Garante que se o usuário fechar o form no “X”, o logout também será salvo
        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistrarLogout();
            registrarlogoutFACE();

        }

        private int funcionarioId;
        private int logId;

        public MenuForm(int funcionarioId = -1, int logId = -1)
        {
            InitializeComponent();
            this.funcionarioId = funcionarioId;
            this.logId = logId;
        }


    }
}

