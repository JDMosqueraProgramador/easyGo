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

            
            //dtgConductores.DataSource = new UserController().ExecuteSearchUser("");
            dtgConductores.DataSource = new UserController().GetDriversDisabled();
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

            try
            {

                int id = int.Parse(dtgConductores.SelectedRows[0].Cells[6].Value.ToString());

                dataMoto = MotorcycleController.GetMoto(id);
                dataPapers = MotorcycleController.GetPapers(dataMoto.StrLicensePlateMoto);

                lblNombreConductor.Text = dataMoto.Driver.StrNamePerson;
                lblApellidoConductor.Text = dataMoto.Driver.StrLastNamePerson;
                lblEmailConductor.Text = dataMoto.Driver.StrEmailUser;
                lblNumeroCelularConductor.Text = dataMoto.Driver.IntPhoneUser.ToString();
                lblFechaNacimientoConductor.Text = dataMoto.Driver.DateOfBirthPerson.ToString();
                lblCiudadConductor.Text = dataMoto.Driver.City;
                lblGeneroConductor.Text = (dataMoto.Driver.BoolGenderPerson) ? "Masculino" : "Femenino";
                lblRolConductor.Text = dataMoto.Driver.StrRolUser;

                /*lblPrueba.Text = value.ToString();*/

                lblNumeroLicenciacc.Text = dataPapers.Intnumlicense.ToString();
                lblFechaVigenciaHastaLicencia.Text = dataPapers.Datevaliditylicense.ToString();
                dateVigenciaHastaTecno.Text = dataPapers.Datevaliduntiltechnomechanical.ToString();
                lblIdSoat.Text = dataPapers.Intidsoat.ToString();
                lblFechaVigenciaHastaSoat.Text = dataPapers.Datevaliduntilsoat.ToString();

                //fotos

                fotoLicencia.Image = Image.FromFile($"../../../wEasyGoDriver{dataPapers.Strimagelicense.Replace("../..", "")}");
                FotoTecno.Image = Image.FromFile($"../../../wEasyGoDriver{dataPapers.Strurltechnomechanical.Replace("../..", "")}");
                fotoSoat.Image = Image.FromFile($"../../../wEasyGoDriver{dataPapers.Strurlsoat.Replace("../..", "")}");
                fotoTarjetaPropiedad.Image = Image.FromFile($"../../../wEasyGoDriver{dataMoto.StrLinkPropertyCard.Replace("../..", "")}");

                lblPLaca.Text = dataMoto.StrLicensePlateMoto;
                lblNumeroLicenciaMoto.Text = dataMoto.IntNumLicenseMoto.ToString();
                lblCilindraje.Text = dataMoto.IntCylinderMoto.ToString();
                lblMarcaMoto.Text = dataMoto.StrMarkMoto.ToString();
                lblTipoCombustible.Text = dataMoto.StrFuelTypeMoto.ToString();
                lblModeloMotocicleta.Text = dataMoto.StrModelMoto.ToString();
                lblColorMotocicleta.Text = dataMoto.StrColorMoto.ToString();
                lblEstadoMoto.Text = dataMoto.StrStateMoto;

                if (dataMoto.StrStateMoto == "disabled")
                {
                    btnHabilitar.Text = "Habilitar";
                }
                else
                {
                    btnHabilitar.Text = "Deshabilitar";
                }

                tabsValidar.SelectedTab = tabDatosConductor;


            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }

        }

        private void dtgConductores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataMoto.StrStateMoto == "disabled")
                {
                    if (MotorcycleController.ExecuteChangeState("inactive", dataMoto.StrLicensePlateMoto))
                    {
                        dataMoto.StrStateMoto = "inactive";
                        MessageBox.Show($"Ha habilitado la moto {dataMoto.StrLicensePlateMoto} para realizar viajes");
                        btnHabilitar.Text = "Deshabilitar";
                    }
                }
                else
                {
                    if (MotorcycleController.ExecuteChangeState("disabled", dataMoto.StrLicensePlateMoto))
                    {
                        dataMoto.StrStateMoto = "disabled";
                        MessageBox.Show($"Ha deshabilitado la moto {dataMoto.StrLicensePlateMoto} para realizar viajes");
                        btnHabilitar.Text = "Habilitar";
                    }
                }

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
    }
}
