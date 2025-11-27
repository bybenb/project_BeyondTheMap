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
    public partial class ResumoReservaForm : Form
    {
        public bool Confirmado { get; private set; } = false;

        public ResumoReservaForm(string resumo)
        {
            InitializeComponent();
            textBoxResumo.Text = resumo;
        }
     

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {

            Confirmado = true;
            this.Close();

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

            Confirmado = false;
            this.Close();

        }
    }
}
