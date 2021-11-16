using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wEasyGoAdmin.Controller;
using wEasyGoAdmin.Model;
using LibClassEasyGo;

namespace wEasyGoAdmin.View
{
    public partial class frmMain : Form
    {

        string conductor="";


        IMotorcycle dataMoto;
        Papers dataPapers;

        UserController userController;

        public frmMain(long phone)
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtNombreConductor.Text = "Nombre del conductor";
            txtNombreConductor.ForeColor = Color.DimGray;

        }

        private void txtNombreConductor_Enter(object sender, EventArgs e)
        {
            txtNombreConductor.Text = "";
            txtNombreConductor.ForeColor = Color.DimGray;
        }

        private void txtNombreConductor_Leave(object sender, EventArgs e)
        {
            conductor = txtNombreConductor.Text;

            if (conductor.Equals("Nombre del conductor"))
            {
                txtNombreConductor.Text = "Nombre del conductor";
                txtNombreConductor.ForeColor = Color.DimGray;

            }
            else
            {
                if (conductor.Equals(""))
                {
                    txtNombreConductor.Text = "Nombre del conductor";
                    txtNombreConductor.ForeColor = Color.DimGray;
                }
                else
                {
                    txtNombreConductor.Text = conductor;
                    txtNombreConductor.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtNombreConductor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreConductor.Text != "")
                {
                    dtgConductores.DataSource = new UserController().ExecuteSearchUser(txtNombreConductor.Text);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                throw;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnAvanzarPapeles_Click(object sender, EventArgs e)
        {
            tabsValidar.SelectedTab = tabPapeles;
        }

        private void btnAvanzarDatosvehiculo_Click(object sender, EventArgs e)
        {
            tabsValidar.SelectedTab = lblVinMotocicleta;
        }

        private void dtgConductores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int id = int.Parse(dtgConductores.Rows[0].Cells[6].Value.ToString());

            dataMoto = MotorcycleController.GetMoto(id);
            dataPapers = MotorcycleController.GetPapers(dataMoto.StrLicensePlateMoto);

            lblNombreConductor.Text = dataMoto.Driver.StrNamePerson;
            lblApellidoConductor.Text = dataMoto.Driver.StrLastNamePerson;
            lblEmailConductor.Text = dataMoto.Driver.StrEmailUser;
            lblNumeroCelularConductor.Text = dataMoto.Driver.IntPhoneUser.ToString();
            lblFechaNacimientoConductor.Text = dataMoto.Driver.DateOfBirthPerson.ToString();
            lblCiudadConductor.Text = dataMoto.Driver.City;
            lblGeneroConductor.Text = dataMoto.Driver.BoolGenderPerson.ToString();
            lblRolConductor.Text = dataMoto.Driver.StrRolUser;


            /*lblPrueba.Text = value.ToString();*/

            lblNumeroLicenciacc.Text = dataPapers.Intnumlicense.ToString();
            lblFechaVigenciaHastaLicencia.Text = dataPapers.Datevaliditylicense.ToString();
            dateVigenciaHastaTecno.Text = dataPapers.Datevaliduntiltechnomechanical.ToString();
            lblIdSoat.Text = dataPapers.Intidsoat.ToString();
            lblFechaVigenciaHastaSoat.Text = dataPapers.Datevaliduntilsoat.ToString();

            //fotos

            fotoLicencia.Text = dataPapers.Strimagelicense.ToString();
            FotoTecno.Text = dataPapers.Strurltechnomechanical.ToString();
            fotoSoat.Text = dataPapers.Strurlsoat.ToString();

            lblPLaca.Text = dataMoto.StrLicensePlateMoto;
            lblNumeroLicenciaMoto.Text = dataMoto.IntNumLicenseMoto.ToString();
            lblCilindraje.Text = dataMoto.IntCylinderMoto.ToString();
            lblMarcaMoto.Text = dataMoto.StrMarkMoto.ToString();
            lblTipoCombustible.Text = dataMoto.StrFuelTypeMoto.ToString();
            lblModeloMotocicleta.Text = dataMoto.StrModelMoto.ToString();
            lblColorMotocicleta.Text = dataMoto.StrColorMoto.ToString();


            tabsValidar.SelectedTab = tabDatosConductor;
        }

        private void dtgConductores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
