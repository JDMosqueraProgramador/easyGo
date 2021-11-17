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
using wEasyGoAdmin.View;

namespace wEasyGoAdmin
{
    public partial class frmLogin : Form
    {

        string user = "";
        string pass = "";


        UserController UserController = new UserController();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void lnklblRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Si es empleado solicite una cuenta con el dueño o los administradores antes de poder ingresar.");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtusername.Text != "" && txtContraseña.Text != "")
                {

                    if (UserController.ExecuteLogin(Convert.ToInt64(txtusername.Text), txtContraseña.Text))
                    {
                        //this.Close();
                        MessageBox.Show("Acceso concedido");
                        new frmMain(Convert.ToInt64(txtusername.Text)).Show();


                    }
                    else
                    {
                        MessageBox.Show("El número telefónico es incorrecto", "Acceso denegado");
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos", "Acceso denegado");
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            txtContraseña.Text = "";
            txtContraseña.ForeColor = Color.DimGray;
            txtContraseña.PasswordChar = '*';
            txtContraseña.ForeColor = Color.DimGray;
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            txtContraseña.Text = "";
            txtContraseña.ForeColor = Color.DimGray;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtusername.Text = "Número de celular";
            txtusername.ForeColor = Color.DimGray;
            txtContraseña.PasswordChar = '\0';
            txtContraseña.Text = "Contraseña";
            txtContraseña.ForeColor = Color.DimGray;

        }

        private void txtusername_Leave(object sender, EventArgs e)
        {

            user = txtusername.Text;

            if (user.Equals("Número de celular"))
            {
                txtusername.Text = "Número de celular";
                txtusername.ForeColor = Color.DimGray;

            }
            else
            {
                if (user.Equals(""))
                {
                    txtusername.Text = "Número de celular";
                    txtusername.ForeColor = Color.DimGray;
                }
                else
                {
                    txtusername.Text = user;
                    txtusername.ForeColor = Color.DimGray;
                }
            }

        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {

            pass = txtContraseña.Text;

            if (pass.Equals("Contraseña"))
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.DimGray;

            }
            else
            {
                if (pass.Equals(""))
                {
                    txtContraseña.PasswordChar = '\0';
                    txtContraseña.Text = "Contraseña";
                    txtContraseña.ForeColor = Color.DimGray;

                }
                else
                {
                    txtContraseña.PasswordChar = '*';
                    txtContraseña.Text = pass;
                    txtContraseña.ForeColor = Color.DimGray;
                }


            }

        }
    }
}
