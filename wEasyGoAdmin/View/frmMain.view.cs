﻿using System;
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

        IUser dataUser;


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
            lblNumeroLicencia.SelectedTab = tabPapeles;
        }

        private void btnAvanzarDatosvehiculo_Click(object sender, EventArgs e)
        {
            lblNumeroLicencia.SelectedTab = lblVinMotocicleta;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtgConductores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgConductores_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int id;
            id = int.Parse(dtgConductores.Rows[0].Cells[0].Value.ToString());

            /*lblPrueba.Text = value.ToString();*/


        }
    }
}
