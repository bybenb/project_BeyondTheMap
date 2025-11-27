using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservaDeViagens
{
    public partial class AdminMenuForm : Form
    {
        public AdminMenuForm()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminClientForm formPrincipal = new AdminClientForm();
            formPrincipal.ShowDialog();
            this.Show();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminFuncionarioForm formPrincipal = new AdminFuncionarioForm();
            formPrincipal.ShowDialog();
            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
