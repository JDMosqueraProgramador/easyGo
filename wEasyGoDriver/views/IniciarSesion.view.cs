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
using wEasyGoDriver.controllers;

namespace wEasyGoDriver.views
{
    public partial class frmIniciarSesion : Form
    {

        string username = "";
        string pass = "";
        UserController userController;
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
            this.Hide();
            new frmRegistro().Show();
            
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            new frmMain(3127022532).Show();

            /* userController = new UserController();
            if (userController.ExecuteLogin(Convert.ToInt64(txtusername.Text), txtContraseña.Text))
            {
                new frmRegistro().Show();
            } */
        }

        private void frmIniciarSesion_Load(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '\0';
            txtContraseña.Text = "Contraseña";
            txtContraseña.ForeColor = Color.DimGray;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtusername_Enter(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtusername.ForeColor = Color.DimGray;
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            username = txtusername.Text;

            if (username.Equals("Número de celular"))
            {
                txtusername.Text = "Número de celular";
                txtusername.ForeColor = Color.DimGray;

            }
            else
            {
                if (username.Equals(""))
                {
                    txtusername.Text = "Número de celular";
                    txtusername.ForeColor = Color.DimGray;

                }
                else
                {
                    txtusername.Text = username;
                    txtusername.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {

            txtContraseña.Text = "";
            txtContraseña.ForeColor = Color.DimGray;
            txtContraseña.PasswordChar = '*';
            txtContraseña.ForeColor = Color.DimGray;
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
