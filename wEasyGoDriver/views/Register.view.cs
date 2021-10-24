using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wEasyGoDriver.controls;


namespace wEasyGoDriver
{
    public partial class frmEasyGoDriver : Form
    {
        UserController user;
        public frmEasyGoDriver()
        {
            InitializeComponent();
        }

        private void btnAddID_Click(object sender, EventArgs e)
        {
            UserController user = new UserController();

            user.getIdentification("D:/Projects/EasyGo/wEasyGoDriver/assets/prueba1.jpg");

            pictureBox1.Image = user.bitImg;

            MessageBox.Show(user.Text);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool genero = (cmbGenero.Text == "Masculino" && cmbGenero.Text != "") ? true : false;

            string rol = "Driver";
            rol = (rdoDueño.Checked) ? "Owner" : "Driver";

            user = new UserController(Convert.ToInt64(txtCedula.Text), txtNombre.Text, txtApellidos.Text, dateOfBirthPerson.Value, genero, Convert.ToInt64(txtNumeroCelular.Text), txtCorreo.Text, rol);
            if(user.ExecuteSetUser(txtContraseña.Text, 1) == 1)
            {
                MessageBox.Show("Registrado");
            }
        }

        private void frmEasyGoDriver_Load(object sender, EventArgs e)
        {

        }
    }
}
