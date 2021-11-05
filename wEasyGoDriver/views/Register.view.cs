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
using System.IO;

namespace wEasyGoDriver
{
    public partial class frmRegistro : Form
    {
        UserController userController;
        List<City> cities = new CityController().getCities();

        IUser DataUser;
        public frmRegistro()
        {
            InitializeComponent();
            InicializeForm();
        }

        public void InicializeForm()
        {
            cmbCiudad.Items.Clear();

            foreach (City city in cities)
            {
                cmbCiudad.Items.Add(city.StrNameCity);
            }

            //// Colores 
            cmbColorMotocicleta.Items.Clear();

            cmbColorMotocicleta.Items.AddRange(new object[]{ "Rojo", "Amarillo", "Gris", "Negro", "Blanco", "Azul"});
            cmbTipoCombustible.Items.AddRange(new object[] { "Gasolina", "Eléctrico" });
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
            try
            {
                int idCity = cities[cities.FindIndex(city => city.StrNameCity == cmbCiudad.Text)].IntIdCity;
                bool genero = (cmbGenero.Text == "Masculino" && cmbGenero.Text != "") ? true : false;

                string rol = "Driver";
                rol = (rdoDueño.Checked) ? "Owner" : "Driver";

                userController = new UserController(Convert.ToInt64(txtCedula.Text), txtNombre.Text, txtApellidos.Text, dateOfBirthPerson.Value, genero, Convert.ToInt64(txtNumeroCelular.Text), txtCorreo.Text, rol);
                if (userController.ExecuteSetUser(txtContraseña.Text, idCity) == 1)
                {
                    tabsRegistros.SelectedTab = (rdoDueño.Checked) ? tabVehiculo : tabLicencia;
                    userController = new UserController(Convert.ToInt64(txtNumeroCelular.Text));

                    DataUser = userController.getDataUser();
                    MessageBox.Show("Registrado, continúe con los pasos del registro");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnRegistrarLicencia_Click(object sender, EventArgs e)
        {
            try
            {
                LicenseController license = new LicenseController(Convert.ToInt32(txtNumerodeLicencia.Text), dateVigenciaHastaLicencia.Value, DataUser.IntIdPerson, btnCargarimgLicencia.Tag.ToString());
                if(license.ExecuteInsertLicense())
                {
                    MessageBox.Show("Licencia registrada");
                    if(rdoSiVehiculo.Checked)
                    {
                        txtAsignarConductor.Visible = false;
                        iconAsignarConductor.Visible = false;
                        imgBackAsignarConductor.Visible = false;
                        dtgBuscarConductor.Visible = false;
                        lblSeleccioneConductor.Visible = false;
                        tabsRegistros.SelectedTab = tabVehiculo;

                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnRegistrarMoto_Click(object sender, EventArgs e)
        {
            MotorcycleControlller motoController;
            try
            {
                if (rdoSiVehiculo.Checked)
                {
                    motoController = new MotorcycleControlller(txtPlaca.Text, Convert.ToInt32(txtNumeroSerie.Text), Convert.ToInt32(txtNumeroChasis.Text), Convert.ToInt32(txtVin.Text), Convert.ToInt32(txtNumeroLicenciaMoto.Text), txtMarca.Text, Convert.ToInt32(txtCilindraje.Text), txtModelo.Text, cmbTipoCombustible.Text, btnCargarTarjPropiedad.Tag.ToString(), DataUser.IntIdUser, DataUser.IntIdUser, cmbColorMotocicleta.Text);
                }
                else
                {
                    motoController = new MotorcycleControlller(txtPlaca.Text, Convert.ToInt32(txtNumeroSerie.Text), Convert.ToInt32(txtNumeroChasis.Text), Convert.ToInt32(txtVin.Text), Convert.ToInt32(txtNumeroLicenciaMoto.Text), txtMarca.Text, Convert.ToInt32(txtCilindraje.Text), txtModelo.Text, cmbTipoCombustible.Text, btnCargarTarjPropiedad.Tag.ToString(), DataUser.IntIdUser, Convert.ToInt32(dtgBuscarConductor.SelectedRows[0].Cells[6].Value), cmbColorMotocicleta.Text);
                }

                if (motoController.ExecuteInsertMoto())
                {
                    MessageBox.Show("Moto registrada");
                    tabsRegistros.SelectedTab = tabPapelesVehiculo;

                }
                else
                {
                    throw new Exception("Ha ocurrido un error al registrar la moto");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnRegistrarPapeles_Click(object sender, EventArgs e)
        {
            try
            {
                SoatController soat = new SoatController(Convert.ToInt32(txtIdSoat.Text), dateVigenciaHastaSoat.Value, btnCargarImgSoat.Tag.ToString(), txtPlaca.Text);
                TechnomechanicalController tecno = new TechnomechanicalController(dateVigenciaHastaTecno.Value, btnCargarImgTecno.Tag.ToString(), txtPlaca.Text);
                if (soat.ExecuteinsertSoat() && tecno.ExecuteInsertTechnomechanical())
                {
                    MessageBox.Show("Soat y tecnomicanica agregados correctamente");
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }

        public string uploadFile(string folder, string name)
        {
            string route = null;

            OpenFileDialog searchFile = new OpenFileDialog();
            searchFile.Multiselect = false;
            searchFile.Filter = "Archivos|*.jpg; *.jpeg; *.png; *.svg";

            if (searchFile.ShowDialog() == DialogResult.OK)
            {
                if (searchFile.CheckFileExists)
                {
                    
                    route = $"../../assets/{folder}/{name}.png";

                    if (System.IO.File.Exists(route))
                    {
                        System.IO.File.Replace(searchFile.FileName, route, $"../../assets/backups/{name}Backups{new Random().Next(0, 10000)}.png");
                    }
                    else
                    {
                        System.IO.File.Copy(searchFile.FileName, route);
                    }
                } 
                else
                {
                    throw new Exception("Archivo inválido");
                }
            }

            return route;
        }


        private void btnCargarimgLicencia_Click(object sender, EventArgs e)
        {
            try
            {
                btnCargarimgLicencia.Tag = uploadFile("licencias", DataUser.IntIdUser.ToString());
                if (btnCargarimgLicencia.Tag != null)
                {
                    MessageBox.Show("Imagen de licencia cargada");
                    btnCargarimgLicencia.Text = "Cambiar imagen de licencia";
                }
                else
                {
                    throw new Exception("Error al cargar imagen");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message); 
            }
        }

        private void btnCargarTarjPropiedad_Click(object sender, EventArgs e)
        {
            try
            {
                btnCargarTarjPropiedad.Tag = uploadFile("tarjetasPropiedad", DataUser.IntIdUser.ToString());
                if (btnCargarTarjPropiedad.Tag != null)
                {
                    MessageBox.Show("Imagen de propiedad cargada");
                    btnCargarTarjPropiedad.Text = "Cambiar imagen de tarjeta de propiedad";
                }
                else
                {
                    throw new Exception("Error al cargar imagen");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCargarImgTecno_Click(object sender, EventArgs e)
        {
            try
            {
                btnCargarImgTecno.Tag = uploadFile("tecnomecanicas", DataUser.IntIdUser.ToString());
                if (btnCargarImgTecno.Tag != null)
                {
                    MessageBox.Show("Imagen tecnomecanicas cargada");
                    btnCargarImgTecno.Text = "Cambiar imagen de tecnomecanica";
                }
                else
                {
                    throw new Exception("Error al cargar imagen");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnCargarImgSoat_Click(object sender, EventArgs e)
        {
            try
            {
                btnCargarImgSoat.Tag = uploadFile("soat", DataUser.IntIdUser.ToString());
                if (btnCargarImgSoat.Tag != null)
                {
                    MessageBox.Show("Imagen soat cargada");
                    btnCargarImgSoat.Text = "Cambiar imagen de soat";
                }
                else
                {
                    throw new Exception("Error al cargar imagen");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void txtAsignarConductor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAsignarConductor.Text != "")
                {
                    dtgBuscarConductor.DataSource = new UserController().ExecuteSearchUser(txtAsignarConductor.Text);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                throw;
            }
        }
    }
}
