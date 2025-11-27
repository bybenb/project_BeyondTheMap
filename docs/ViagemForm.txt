using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

using MySql.Data.MySqlClient;

namespace ReservaDeViagens
{
    public partial class ViagemForm : Form
    {

        string data_source = "datasource=localhost;username=root;password=;database=tripagency";

        private int clienteId;

        private string nomeCliente;

        public ViagemForm(int clienteId)
        {
            InitializeComponent();
            this.clienteId = clienteId;
        }



        private void ViagemForm_Load(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = "SELECT nome FROM clientes WHERE Id_Cliente = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", clienteId);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    nomeCliente = result.ToString();
                    this.Text = "Viagem de " + nomeCliente;
                }
            }



            if (comboBoxPaises.Items.Count == 0)
            {
                CarregarPaises();
                comboBoxPaises.SelectedIndexChanged += comboBoxPaises_SelectedIndexChanged;
                comboBoxCidades.SelectedIndexChanged += comboBoxCidades_SelectedIndexChanged;
            }

        }
        
        private void CarregarPaises()
        {
            comboBoxPaises.Items.Clear();
            comboBoxPaises.Tag = null;

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = "SELECT id, nome FROM paises ORDER BY nome;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, int> paises = new Dictionary<string, int>();

                while (reader.Read())
                {
                    string nome = reader.GetString("nome");
                    int id = reader.GetInt32("id");

                    if (!paises.ContainsKey(nome)) // evita duplicação
                    {
                        paises[nome] = id;
                        comboBoxPaises.Items.Add(nome);
                    }
                }

                comboBoxPaises.Tag = paises;
                reader.Close();
            }
        }

        private void comboBoxPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCidades.Items.Clear();
            comboBoxCompanhias.Items.Clear();

            string paisSelecionado = comboBoxPaises.SelectedItem.ToString();
            var paises = (Dictionary<string, int>)comboBoxPaises.Tag;
            int paisId = paises[paisSelecionado];

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = "SELECT id, nome FROM cidades WHERE pais_id = @paisId ORDER BY nome;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@paisId", paisId);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, int> cidades = new Dictionary<string, int>();
                while (reader.Read())
                {
                    string nome = reader.GetString("nome");
                    int id = reader.GetInt32("id");
                    cidades[nome] = id;
                    comboBoxCidades.Items.Add(nome);
                }

                comboBoxCidades.Tag = cidades;
                reader.Close();
            }

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = "SELECT nome FROM companhias WHERE id_paises = @paisId ORDER BY nome;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@paisId", paisId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxCompanhias.Items.Add(reader.GetString("nome"));
                }

                reader.Close();
            }
        }

        private void comboBoxCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxHoteis.Items.Clear();
            comboBoxAeroportos.Items.Clear();

            string cidadeSelecionada = comboBoxCidades.SelectedItem.ToString();
            var cidades = (Dictionary<string, int>)comboBoxCidades.Tag;
            int cidadeId = cidades[cidadeSelecionada];

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = "SELECT nome FROM hoteis WHERE cidades_id = @cidadeId ORDER BY nome;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cidadeId", cidadeId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxHoteis.Items.Add(reader.GetString("nome"));
                }

                reader.Close();
            }

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                string query = "SELECT id, nome FROM aeroportos WHERE cidades_id = @cidadeId ORDER BY nome;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cidadeId", cidadeId);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, int> aeroportos = new Dictionary<string, int>();
                while (reader.Read())
                {
                    comboBoxAeroportos.Items.Add(reader.GetString("nome"));

                    string nome = reader.GetString("nome");
                    int id = reader.GetInt32("id");
                   
                    aeroportos[nome] = id;

                }
                comboBoxAeroportos.Tag = aeroportos;


                reader.Close();
            }


        }


        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int clienteId = this.clienteId;

            var paises = (Dictionary<string, int>)comboBoxPaises.Tag;
            var cidades = (Dictionary<string, int>)comboBoxCidades.Tag;

            int paisId = paises[comboBoxPaises.SelectedItem.ToString()];
            int cidadeId = cidades[comboBoxCidades.SelectedItem.ToString()];
            string hotelNome = comboBoxHoteis.SelectedItem.ToString();
            string companhiaNome = comboBoxCompanhias.SelectedItem.ToString();
            string classeViagem = classeDaViagem.SelectedItem?.ToString();

            var aeroportos = (Dictionary<string, int>)comboBoxAeroportos.Tag;
            int aeroportoId = aeroportos[comboBoxAeroportos.SelectedItem.ToString()];

            int pessoas = int.Parse(quantasPessoas.Text);
            int dias = int.Parse(quantosDias.Text);

            DateTime dataPartida = dateTimePicker1.Value.Date;
            DateTime dataRetorno = dataPartida.AddDays(dias);

            decimal precoHotel = 0;
            decimal precoPassagem = 0;

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();

                // Buscar preço do hotel
                string queryHotel = "SELECT precoHoteis FROM hoteis WHERE nome = @nome AND cidades_id = @cidadeId LIMIT 1;";
                using (MySqlCommand cmd = new MySqlCommand(queryHotel, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", hotelNome);
                    cmd.Parameters.AddWithValue("@cidadeId", cidadeId);
                    object result = cmd.ExecuteScalar();
                    precoHotel = result != null ? Convert.ToDecimal(result) : 0;
                }

                // Buscar preço da passagem
                string queryPassagem = "SELECT precoCompanhias FROM companhias WHERE nome = @nome AND id_paises = @paisId LIMIT 1;";
                using (MySqlCommand cmd = new MySqlCommand(queryPassagem, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", companhiaNome);
                    cmd.Parameters.AddWithValue("@paisId", paisId);
                    object result = cmd.ExecuteScalar();
                    precoPassagem = result != null ? Convert.ToDecimal(result) : 0;
                }

                // Cálculo do valor total



                decimal totalHotel = precoHotel * dias * pessoas;
                decimal totalPassagem = precoPassagem * pessoas;
                decimal totalGeral = totalHotel + totalPassagem;

                decimal percentualAcrescimo = 0;

                switch (classeViagem)
                {
                    case "Económica":
                        percentualAcrescimo = 1.08m;
                        break;
                    case "Executiva":
                        percentualAcrescimo = 1.14m;
                        break;
                    case "Primeira Classe":
                        percentualAcrescimo = 1.23m;
                        break;
                }

                totalGeral += totalGeral * percentualAcrescimo;



                int hotelId = 0;
                int companhiaId = 0;

                // Buscar hotel_id
                string queryHotelId = "SELECT id FROM hoteis WHERE nome = @nome AND cidades_id = @cidadeId LIMIT 1;";
                using (MySqlCommand cmd = new MySqlCommand(queryHotelId, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", hotelNome);
                    cmd.Parameters.AddWithValue("@cidadeId", cidadeId);
                    object result = cmd.ExecuteScalar();
                    hotelId = result != null ? Convert.ToInt32(result) : 0;
                }

                // Buscar companhia_id
                string queryCompanhiaId = "SELECT id FROM companhias WHERE nome = @nome AND id_paises = @paisId LIMIT 1;";
                using (MySqlCommand cmd = new MySqlCommand(queryCompanhiaId, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", companhiaNome);
                    cmd.Parameters.AddWithValue("@paisId", paisId);
                    object result = cmd.ExecuteScalar();
                    companhiaId = result != null ? Convert.ToInt32(result) : 0;
                }

                
                string resumo = $"\n--- Comprovativo da Reserva ---\n\n" +
                $"Cliente: {nomeCliente}\n" +
                $"Destino: {comboBoxCidades.SelectedItem}, {comboBoxPaises.SelectedItem}\n" +
                $"Hotel: {hotelNome}\n" +
                $"Companhia: {companhiaNome} ({classeViagem})\n" +
                $"Aeroporto: {comboBoxAeroportos.SelectedItem}\n" +
                $"Pessoas: {pessoas}\nDias: {dias}\n" +
                $"Data Partida: {dataPartida:dd/MM/yyyy}\n" +
                $"Data Retorno: {dataRetorno:dd/MM/yyyy}\n\n" +
                $"Preço Total: $ {totalGeral:F2}";

                ResumoReservaForm resumoForm = new ResumoReservaForm(resumo);
                resumoForm.ShowDialog();

                if (!resumoForm.Confirmado)
                {
                    MessageBox.Show("Reserva cancelada pelo usuário.");
                    return;
                }



                
                string insertQuery = @"INSERT INTO reservas 
            (cliente_id, pais_id, cidade_id, hotel_id, aeroporto_id, companhia_id, classe, dias, pessoas, total_preco, data_viagem, data_retorno)
            VALUES (@clienteId, @paisId, @cidadeId, @hotel_Id, @aeroportoId, @companhia_Id, @classe, @dias, @pessoas, @total, @dataPartida, @dataRetorno);";

                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    cmd.Parameters.AddWithValue("@paisId", paisId);
                    cmd.Parameters.AddWithValue("@cidadeId", cidadeId);
                    cmd.Parameters.AddWithValue("@hotel_Id", hotelId);
                    cmd.Parameters.AddWithValue("@aeroportoId", aeroportoId);
                    cmd.Parameters.AddWithValue("@companhia_Id", companhiaId);
                    cmd.Parameters.AddWithValue("@classe", classeViagem);
                    cmd.Parameters.AddWithValue("@dias", dias);
                    cmd.Parameters.AddWithValue("@pessoas", pessoas);
                    cmd.Parameters.AddWithValue("@total", totalGeral);
                    cmd.Parameters.AddWithValue("@dataPartida", dataPartida);
                    cmd.Parameters.AddWithValue("@dataRetorno", dataRetorno);

                    cmd.ExecuteNonQuery();

                    string caminhoPDF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nomeCliente + totalGeral + " - Reserva.pdf");
                    GerarPDF(resumo, caminhoPDF);
                    MessageBox.Show("Comprovativo gerado com sucesso na área de trabalho.");

                }

                MessageBox.Show("Reserva realizada com sucesso!\nPreço Total: $ " + totalGeral.ToString("F2"));
            }
        }


        private void quantasPessoas_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void quantosDias_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(quantosDias.Text, out int dias))
            {
                DateTime dataPartida = dateTimePicker1.Value;
                DateTime dataRetorno = dataPartida.AddDays(dias);
                lblRetorno.Text = "Data de retorno: " + dataRetorno.ToString("dd/MM/yyyy");
            }
            else
            {
                lblRetorno.Text = "Insira um número válido de dias.";
            }
        }


        private void classeDaViagem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(quantosDias.Text, out int dias))
            {
                DateTime dataPartida = dateTimePicker1.Value;
                DateTime dataRetorno = dataPartida.AddDays(dias);
                lblRetorno.Text = "Data de retorno: " + dataRetorno.ToString("dd/MM/yyyy");
            }
        }

        private void GerarPDF(string conteudo, string caminho)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));
            doc.Open();
            doc.Add(new Paragraph(conteudo));
            doc.Close();
        }


    }
}
