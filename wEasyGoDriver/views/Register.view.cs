using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wEasyGoDriver.controllers;
using LibClassEasyGo;

namespace wEasyGoDriver
{
    public partial class frmRegistro : Form
    {
        UserController userController;

        IUser DataUser;
        public frmRegistro()
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
            //try
            //{

                bool genero = (cmbGenero.Text == "Masculino" && cmbGenero.Text != "") ? true : false;

                string rol = "Driver";
                rol = (rdoDueño.Checked) ? "Owner" : "Driver";

                userController = new UserController(Convert.ToInt64(txtCedula.Text), txtNombre.Text, txtApellidos.Text, dateOfBirthPerson.Value, genero, Convert.ToInt64(txtNumeroCelular.Text), txtCorreo.Text, rol);
                if (userController.ExecuteSetUser(txtContraseña.Text, 1) == 1)
                {
                    tabsRegistros.SelectedTab = (rdoDueño.Checked) ? tabVehiculo : tabLicencia;
                    userController = new UserController(Convert.ToInt64(txtNumeroCelular.Text));

                    DataUser = userController.getDataUser();
                    MessageBox.Show("Registrado, continúe con los pasos del registro");
                }

            /*}
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }*/

        }

        private void btnRegistrarLicencia_Click(object sender, EventArgs e)
        {
            try
            {
                LicenseController license = new LicenseController(Convert.ToInt32(txtNumerodeLicencia.Text), dateVigenciaHastaLicencia.Value, DataUser.IntIdPerson, "");
                if(license.ExecuteInsertLicense())
                {
                    MessageBox.Show("Licencia registrada");
                    if(rdoSiVehiculo.Checked)
                    {
                        tabsRegistros.SelectedTab = tabVehiculo;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoSiVehiculo.Checked)
                {
                    MotorcycleControlller motoController = new MotorcycleControlller(txtPlaca.Text, Convert.ToInt32(txtNumeroSerie.Text), Convert.ToInt32(txtNumeroChasis.Text), Convert.ToInt32(txtVin.Text), Convert.ToInt32(txtNumerodeLicencia.Text), txtMarca.Text, Convert.ToInt32(txtCilindraje.Text), txtModelo.Text, cmbTipoCombustible.Text, "http", DataUser.IntIdUser, DataUser.IntIdUser, cmbColorMotocicleta.Text);

                    if(motoController.ExecuteInsertMoto())
                    {
                        MessageBox.Show("Moto registrada");
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
}

        private void cmbColorMotocicleta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
