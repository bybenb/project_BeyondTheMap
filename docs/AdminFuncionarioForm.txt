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
    public partial class AdminFuncionarioForm : Form
    {
        MySqlConnection Conexao;

        string data_source = "datasource=localhost;username=root;password=;database=tripagency";


        public AdminFuncionarioForm()
        {
            InitializeComponent();
            CarregarFuncionarios();
        }

        private void CarregarFuncionarios()
        {
            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = @"SELECT * FROM funcionarios";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewFuncionario.DataSource = dt;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConfigFuncionarioForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            DateTime dataSelecionada = dataNasc.Value.Date;

            try
            {
                string data_source = "datasource=localhost;username=root;password=;database=tripagency";

                Conexao = new MySqlConnection(data_source);

                using (MySqlConnection conn = new MySqlConnection(data_source))
                {
                    conn.Open();
                    string query = "INSERT INTO funcionarios (Nome, Username, Senha, Numero_do_BI, Nacionalidade, Genero, Endereco, Telefone, Email, Data_de_Nascimento) " +
                                   "VALUES (@nome, @username, @senha, @bi, @nacionalidade, @genero, @endereco, @telefone, @email, @data);";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                    cmd.Parameters.AddWithValue("@senha", textBoxSenha.Text);
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

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }



        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string nomeFuncionario = textBoxBusca.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = @"SELECT * FROM funcionarios WHERE Nome LIKE @nome";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", "%" + nomeFuncionario + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewFuncionario.DataSource = dt;
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            CarregarFuncionarios();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewFuncionario.SelectedRows.Count > 0)
            {
                int funcionariosId = Convert.ToInt32(dataGridViewFuncionario.SelectedRows[0].Cells["id"].Value);
                var confirmar = MessageBox.Show("Deseja realmente eliminar o funcionário?", "Confirmação", MessageBoxButtons.YesNo);
                if (confirmar == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(data_source))
                    {
                        conn.Open();
                        string query = "DELETE FROM funcionarios WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", funcionariosId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Funcionário eliminado com sucesso.");
                    CarregarFuncionarios();
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para eliminar.");
            }
        }

        private void btnCadastrarRosto_Click(object sender, EventArgs e)
        {

            if (dataGridViewFuncionario.SelectedRows.Count > 0)
            {
                int funcionarioId = Convert.ToInt32(dataGridViewFuncionario.SelectedRows[0].Cells["id"].Value);
                string funcionarioNome = dataGridViewFuncionario.SelectedRows[0].Cells["Nome"].Value.ToString();

                // Abre o novo form e passa o ID do funcionário
                CadastrarRostoForm formRosto = new CadastrarRostoForm(funcionarioId, funcionarioNome);
                formRosto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um funcionário primeiro.");
            }

        }

        private void buttonVerMais_Click(object sender, EventArgs e)
        {
            if (dataGridViewFuncionario.SelectedRows.Count > 0)
            {
                int funcionarioId = Convert.ToInt32(dataGridViewFuncionario.SelectedRows[0].Cells["id"].Value);
                string nomeFuncionario = dataGridViewFuncionario.SelectedRows[0].Cells["Nome"].Value.ToString();

                HistoricoAcessosForm historicoForm = new HistoricoAcessosForm(funcionarioId);
                historicoForm.Text = $"Histórico de Acessos - {nomeFuncionario}";
                historicoForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para ver o histórico.");
            }
        }
    }
}
