using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibClassEasyGo;
using wEasyGoDriver.controllers;

namespace wEasyGoDriver.views
{
    public partial class frmPerfilConductor : Form
    {

        IUser dataUser;
        UserController userController;
        IMotorcycle dataMotorcycle;
        MotorcycleControlller moto = new MotorcycleControlller();

        public frmPerfilConductor()
        {
            InitializeComponent();
            InitializeForm();
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


        public frmPerfilConductor(long phone)
        {

            InitializeComponent();

            userController = new UserController(phone);
            dataUser = new UserController(phone).getDataUser();
            dataMotorcycle = moto.ExecuteGetMotorcycle(dataUser.IntIdUser);

            try
            {


                if (userController.getDataUser() == null)
                {
                    MessageBox.Show("Acceso denegado a esta sesión");
                    this.Close();
                }
                else
                {
                    InitializeForm();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public void InitializeForm()
        {
            dataUser = userController.getDataUser();

            lblNombreConductor.Text = dataUser.StrNamePerson;
            lblApellidoConductor.Text = dataUser.StrLastNamePerson;
            lblCiudadConductor.Text = dataUser.City;
            lblEmailConductor.Text = dataUser.StrEmailUser;
            lblGeneroConductor.Text = (dataUser.BoolGenderPerson) ? "Masculino" : "Femenino";
            lblFechaNacimientoConductor.Text = dataUser.DateOfBirthPerson.ToString();
            lblNumeroCelularConductor.Text = dataUser.IntPhoneUser.ToString();
            lblRolConductor.Text = dataUser.StrRolUser;

            lblPlacaMoto.Text = dataMotorcycle.StrLicensePlateMoto;
            lblModeloMoto.Text = dataMotorcycle.StrModelMoto;
            lblMarcaMoto.Text = dataMotorcycle.StrMarkMoto;
            lblColorMoto.Text = dataMotorcycle.StrColorMoto;

        }

    }
}
