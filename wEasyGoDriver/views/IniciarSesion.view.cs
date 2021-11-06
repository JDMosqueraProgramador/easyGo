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
            userController = new UserController();
            if (userController.ExecuteLogin(Convert.ToInt64(txtusername.Text), txtContraseña.Text))
            {
                new frmRegistro().Show();
            }
        }

        private void frmIniciarSesion_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            new frmMain().Show();
        }
    }
}
