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
    public partial class HistoricoAcessosForm : Form
    {
        private int funcionarioId;
        private string data_source = "datasource=localhost;username=root;password=;database=tripagency";

        public HistoricoAcessosForm(int idFuncionario)
        {
            InitializeComponent();
            funcionarioId = idFuncionario;
            CarregarHistorico();
        }

        private void CarregarHistorico()
        {
            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = @"
                                SELECT 
                                    f.Nome AS 'Funcionário',
                                    l.username AS 'Usuário',
                                    l.data_login AS 'Data de Login',
                                    l.data_logout AS 'Data de Logout'
                                FROM log_acessos l
                                INNER JOIN funcionarios f ON l.funcionario_id = f.id
                                WHERE f.id = @id
                                ORDER BY l.data_login DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", funcionarioId);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewHistorico.DataSource = dt;
            }
        }
    }
}
