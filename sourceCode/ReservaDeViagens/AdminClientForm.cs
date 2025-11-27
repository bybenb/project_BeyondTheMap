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
    public partial class AdminClientForm : Form
    {

        string data_source = "datasource=localhost;username=root;password=;database=tripagency";

        public AdminClientForm()
        {
            InitializeComponent();
            CarregarTodasReservas();
        }

        private void CarregarTodasReservas()
        {
            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = @"SELECT r.id, c.nome AS Cliente, p.nome AS Pais, ci.nome AS Cidade,
                                        h.nome AS Hotel, cp.nome AS Companhia, r.classe, r.dias, r.pessoas, 
                                        r.total_preco, r.data_viagem, r.data_retorno
                                 FROM reservas r
                                 JOIN clientes c ON r.cliente_id = c.Id_Cliente
                                 JOIN paises p ON r.pais_id = p.id
                                 JOIN cidades ci ON r.cidade_id = ci.id
                                 JOIN hoteis h ON r.hotel_id = h.id
                                 JOIN companhias cp ON r.companhia_id = cp.id";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewReservas.DataSource = dt;
            }
        }


        private void AdminViewForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string nomeCliente = textBoxBusca.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = @"SELECT r.id, c.nome AS Cliente, p.nome AS Pais, ci.nome AS Cidade,
                                        h.nome AS Hotel, cp.nome AS Companhia, r.classe, r.dias, r.pessoas, 
                                        r.total_preco, r.data_viagem, r.data_retorno
                                 FROM reservas r
                                 JOIN clientes c ON r.cliente_id = c.Id_Cliente
                                 JOIN paises p ON r.pais_id = p.id
                                 JOIN cidades ci ON r.cidade_id = ci.id
                                 JOIN hoteis h ON r.hotel_id = h.id
                                 JOIN companhias cp ON r.companhia_id = cp.id
                                 WHERE c.nome LIKE @nome";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", "%" + nomeCliente + "%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewReservas.DataSource = dt;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservas.SelectedRows.Count > 0)
            {
                int reservaId = Convert.ToInt32(dataGridViewReservas.SelectedRows[0].Cells["id"].Value);
                var confirmar = MessageBox.Show("Deseja realmente cancelar esta reserva?", "Confirmação", MessageBoxButtons.YesNo);
                if (confirmar == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(data_source))
                    {
                        conn.Open();
                        string query = "DELETE FROM reservas WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", reservaId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Reserva cancelada com sucesso.");
                    CarregarTodasReservas();
                }
            }
            else
            {
                MessageBox.Show("Selecione uma reserva para cancelar.");
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            CarregarTodasReservas();
        }

        private void buttonVerCliente_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservas.SelectedRows.Count > 0)
            {
                string nomeCliente = dataGridViewReservas.SelectedRows[0].Cells["Cliente"].Value.ToString();

                using (MySqlConnection conn = new MySqlConnection(data_source))
                {
                    conn.Open();
                    string query = "SELECT Id_Cliente FROM clientes WHERE nome = @nome";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", nomeCliente);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int clienteId = Convert.ToInt32(result);
                        ClienteInfoForm formInfo = new ClienteInfoForm(clienteId);
                        formInfo.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Cliente não encontrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione uma reserva.");
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {

            this.Hide();
            AdminFuncionarioForm formPrincipal = new AdminFuncionarioForm();
            formPrincipal.ShowDialog();
            this.Show();
        }
    }
}
