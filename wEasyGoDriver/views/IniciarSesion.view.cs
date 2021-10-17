using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wEasyGoDriver.views;

namespace wEasyGoDriver.views
{
    public partial class frmIniciarSesion : Form
    {
        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnklblRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmEasyGoDriver().Show();
        }
    }
}
