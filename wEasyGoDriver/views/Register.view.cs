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
using wEasyGoDriver.views;

namespace wEasyGoDriver
{
    public partial class frmRegistro : Form
    {
        string cedula = "";
        string nombre = "";
        string apellidos = "";
        string numeroCelular = "";
        string correoElectronico = "";
        string contraseña = "";

        string placa = "";
        string numeroLicenciaMoto= "";
        string marca= "";
        string cilindraje= "";
        string modelo= "";
        string idSoat = "";
        string numeroLicencia = "";


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

                    this.EnableTab(tabsRegistros.SelectedTab);
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
                LicenseController license = new LicenseController(Convert.ToInt32(txtNumerodeLicencia.Text), dateVigenciaHastaLicencia.Value, DataUser.IntIdUser, btnCargarimgLicencia.Tag.ToString());
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
                        this.EnableTab(tabVehiculo);
                    } else
                    {
                        new frmMain(DataUser.IntPhoneUser).Show();
                        this.Close();
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
                    motoController = new MotorcycleControlller(txtPlaca.Text, Convert.ToInt64(txtNumeroLicenciaMoto.Text), txtMarca.Text, Convert.ToInt32(txtCilindraje.Text), txtModelo.Text, cmbTipoCombustible.Text, btnCargarTarjPropiedad.Tag.ToString(), DataUser.IntIdUser, DataUser.IntIdUser, cmbColorMotocicleta.Text);
                }
                else
                {
                    motoController = new MotorcycleControlller(txtPlaca.Text, Convert.ToInt64(txtNumeroLicenciaMoto.Text), txtMarca.Text, Convert.ToInt32(txtCilindraje.Text), txtModelo.Text, cmbTipoCombustible.Text, btnCargarTarjPropiedad.Tag.ToString(), DataUser.IntIdUser, Convert.ToInt32(dtgBuscarConductor.SelectedRows[0].Cells[6].Value), cmbColorMotocicleta.Text);
                }

                if (motoController.ExecuteInsertMoto())
                {
                    MessageBox.Show("Moto registrada");
                    tabsRegistros.SelectedTab = tabPapelesVehiculo;
                    this.EnableTab(tabPapelesVehiculo);

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
                    new frmMain(DataUser.IntPhoneUser).Show();
                    this.Close();
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
                        //  System.IO.File.Replace(searchFile.FileName, route, $"../../assets/backups/{name}Backups{new Random().Next(0, 10000)}.png");
                        System.IO.File.Delete(route);
                    }

                    System.IO.File.Copy(searchFile.FileName, route);
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

        private void tabPersona_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            this.EnableTab(tabPersona);
        }

        private void txtCedula_Enter(object sender, EventArgs e)
        {
            txtCedula.Text = "";
            txtCedula.ForeColor = Color.DimGray;
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            cedula = txtCedula.Text;

            if (cedula.Equals("Cedula"))
            {
                txtCedula.Text = "Cedula";
                txtCedula.ForeColor = Color.DimGray;
            }
            else
            {
                if (cedula.Equals(""))
                {
                    txtCedula.Text = "Cedula";
                    txtCedula.ForeColor = Color.DimGray;

                }
                else
                {
                    txtCedula.Text = cedula;
                    txtCedula.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtNombre.ForeColor = Color.DimGray;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;

            if (nombre.Equals("Nombre"))
            {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.DimGray;

            }
            else
            {
                if (nombre.Equals(""))
                {
                    txtNombre.Text = "Nombre";
                    txtNombre.ForeColor = Color.DimGray;

                }
                else
                {
                    txtNombre.Text = nombre;
                    txtNombre.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            txtApellidos.Text = "";
            txtApellidos.ForeColor = Color.DimGray;
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            apellidos = txtApellidos.Text;

            if (nombre.Equals("Apellidos"))
            {
                txtApellidos.Text = "Apellidos";
                txtApellidos.ForeColor = Color.DimGray;

            }
            else
            {
                if (apellidos.Equals(""))
                {
                    txtApellidos.Text = "Apellidos";
                    txtApellidos.ForeColor = Color.DimGray;

                }
                else
                {
                    txtApellidos.Text = apellidos;
                    txtApellidos.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtNumeroCelular_Enter(object sender, EventArgs e)
        {
            txtNumeroCelular.Text = "";
            txtNumeroCelular.ForeColor = Color.DimGray;
        }

        private void txtNumeroCelular_Leave(object sender, EventArgs e)
        {
            numeroCelular = txtNumeroCelular.Text;

            if (numeroCelular.Equals("Número celular"))
            {
                txtNumeroCelular.Text = "Número celular";
                txtNumeroCelular.ForeColor = Color.DimGray;

            }
            else
            {
                if (numeroCelular.Equals(""))
                {
                    txtNumeroCelular.Text = "Número celular";
                    txtNumeroCelular.ForeColor = Color.DimGray;

                }
                else
                {
                    txtNumeroCelular.Text = numeroCelular;
                    txtNumeroCelular.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            txtCorreo.Text = "";
            txtCorreo.ForeColor = Color.DimGray;
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            correoElectronico = txtCorreo.Text;

            if (correoElectronico.Equals("Correo electronico"))
            {
                txtCorreo.Text = "Correo electronico";
                txtCorreo.ForeColor = Color.DimGray;

            }
            else
            {
                if (correoElectronico.Equals(""))
                {
                    txtCorreo.Text = "Correo electronico";
                    txtCorreo.ForeColor = Color.DimGray;

                }
                else
                {
                    txtCorreo.Text = correoElectronico;
                    txtCorreo.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            txtContraseña.Text = "";
            txtContraseña.ForeColor = Color.DimGray;
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            contraseña = txtContraseña.Text;

            if (contraseña.Equals("Contraseña"))
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.DimGray;

            }
            else
            {
                if (contraseña.Equals(""))
                {
                    txtContraseña.PasswordChar = '\0';
                    txtContraseña.Text = "Contraseña";
                    txtContraseña.ForeColor = Color.DimGray;

                }
                else
                {
                    txtContraseña.PasswordChar = '*';
                    txtContraseña.Text = contraseña;
                    txtContraseña.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtPlaca_Enter(object sender, EventArgs e)
        {
            txtPlaca.Text = "";
            txtPlaca.ForeColor = Color.DimGray;
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
             placa= txtPlaca.Text;

            if (placa.Equals("Placa"))
            {
                txtPlaca.Text = "Placa";
                txtPlaca.ForeColor = Color.DimGray;

            }
            else
            {
                if (placa.Equals(""))
                {
                    txtPlaca.Text = "Placa";
                    txtPlaca.ForeColor = Color.DimGray;

                }
                else
                {
                    txtPlaca.Text = placa;
                    txtPlaca.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtNumeroLicenciaMoto_Enter(object sender, EventArgs e)
        {
            txtNumeroLicenciaMoto.Text = "";
            txtNumeroLicenciaMoto.ForeColor = Color.DimGray;
        }

        private void txtNumeroLicenciaMoto_Leave(object sender, EventArgs e)
        {
            numeroLicenciaMoto = txtNumeroLicenciaMoto.Text;

            if (numeroLicenciaMoto.Equals("Número licencia"))
            {
                txtNumeroLicenciaMoto.Text = "Número licencia";
                txtNumeroLicenciaMoto.ForeColor = Color.DimGray;

            }
            else
            {
                if (numeroLicenciaMoto.Equals(""))
                {
                    txtNumeroLicenciaMoto.Text = "Número licencia";
                    txtNumeroLicenciaMoto.ForeColor = Color.DimGray;

                }
                else
                {
                    txtNumeroLicenciaMoto.Text = numeroLicenciaMoto;
                    txtNumeroLicenciaMoto.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtMarca_Enter(object sender, EventArgs e)
        {
            txtMarca.Text = "";
            txtMarca.ForeColor = Color.DimGray;
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {
            marca = txtMarca.Text;

            if (marca.Equals("Marca"))
            {
                txtMarca.Text = "Marca";
                txtMarca.ForeColor = Color.DimGray;

            }
            else
            {
                if (marca.Equals(""))
                {
                    txtMarca.Text = "Marca";
                    txtMarca.ForeColor = Color.DimGray;

                }
                else
                {
                    txtMarca.Text = marca;
                    txtMarca.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtCilindraje_Enter(object sender, EventArgs e)
        {
            txtCilindraje.Text = "";
            txtCilindraje.ForeColor = Color.DimGray;
        }

        private void txtCilindraje_Leave(object sender, EventArgs e)
        {
            cilindraje = txtCilindraje.Text;

            if (cilindraje.Equals("Cilindraje"))
            {
                txtCilindraje.Text = "Cilindraje";
                txtCilindraje.ForeColor = Color.DimGray;

            }
            else
            {
                if (cilindraje.Equals(""))
                {
                    txtCilindraje.Text = "Cilindraje";
                    txtCilindraje.ForeColor = Color.DimGray;

                }
                else
                {
                    txtCilindraje.Text = cilindraje;
                    txtCilindraje.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtModelo_Enter(object sender, EventArgs e)
        {
            txtModelo.Text = "";
            txtModelo.ForeColor = Color.DimGray;
        }

        private void txtModelo_Leave(object sender, EventArgs e)
        {
            modelo = txtModelo.Text;

            if (modelo.Equals("Modelo"))
            {
                txtModelo.Text = "Modelo";
                txtModelo.ForeColor = Color.DimGray;

            }
            else
            {
                if (modelo.Equals(""))
                {
                    txtModelo.Text = "Modelo";
                    txtModelo.ForeColor = Color.DimGray;

                }
                else
                {
                    txtModelo.Text = modelo;
                    txtModelo.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtIdSoat_Enter(object sender, EventArgs e)
        {
            txtIdSoat.Text = "";
            txtIdSoat.ForeColor = Color.DimGray;
        }

        private void txtIdSoat_Leave(object sender, EventArgs e)
        {
            idSoat = txtIdSoat.Text;

            if (idSoat.Equals("Id soat"))
            {
                txtIdSoat.Text = "Id soat";
                txtIdSoat.ForeColor = Color.DimGray;

            }
            else
            {
                if (idSoat.Equals(""))
                {
                    txtIdSoat.Text = "Id soat";
                    txtIdSoat.ForeColor = Color.DimGray;

                }
                else
                {
                    txtIdSoat.Text = idSoat;
                    txtIdSoat.ForeColor = Color.DimGray;
                }
            }
        }

        private void tabLicencia_Enter(object sender, EventArgs e)
        {

        }

        private void txtNumerodeLicencia_Enter(object sender, EventArgs e)
        {
            txtNumerodeLicencia.Text = "";
            txtNumerodeLicencia.ForeColor = Color.DimGray;
        }

        private void txtNumerodeLicencia_Leave(object sender, EventArgs e)
        {
            numeroLicencia = txtNumerodeLicencia.Text;

            if (numeroLicencia.Equals("Número Licencia"))
            {
                txtNumerodeLicencia.Text = "Número Licencia";
                txtNumerodeLicencia.ForeColor = Color.DimGray;

            }
            else
            {
                if (numeroLicencia.Equals(""))
                {
                    txtNumerodeLicencia.Text = "Número Licencia";
                    txtNumerodeLicencia.ForeColor = Color.DimGray;
                }
                else
                {
                    txtNumerodeLicencia.Text = numeroLicencia;
                    txtNumerodeLicencia.ForeColor = Color.DimGray;
                }
            }
            
        }

        private void txtNumeroCelular_TextChanged(object sender, EventArgs e)
        {

        }

        public void EnableTab(TabPage page)
        {
            foreach (Control ctl in this.tabsRegistros.TabPages) ctl.Enabled = false;

            ((Control)page).Enabled = true;
        }

        private void dtgBuscarConductor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgBuscarConductor_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
