using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wEasyGoDriver.views
{
    public partial class frmPerfilConductor : Form
    {


        public frmPerfilConductor()
        {
            InitializeComponent();
        }

        private void cerrarForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPerfilConductor_Load(object sender, EventArgs e)
        {

        }

       /* public Main(long phone)
        {

            InitializeComponent();

            userController = new UserController(phone);
            if (userController.getDataUser() == null)
            {

                MessageBox.Show("Acceso denegado a esta sesión");
                this.Close();

            }
            else
            {
                InitializeForm();
                initializeSignal();

            }

        }*/
    }
}
