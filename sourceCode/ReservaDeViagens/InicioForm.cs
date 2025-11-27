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
    public partial class InicioForm : Form
    {
        public InicioForm()
        {
            InitializeComponent();
        }

        private void InicioForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult fechar;

            fechar = MessageBox.Show("Deseja sair do sistema?", "Sair?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (fechar == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (fechar == DialogResult.No)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
            LerRostoForm formPrincipal = new LerRostoForm();
            formPrincipal.Show();
            this.Close();
        }


        private void btnCam_Click(object sender, EventArgs e)
        {
          
            LerRostoForm formPrincipal = new LerRostoForm();
            formPrincipal.Show();
            this.Close();
        }
    }
}
