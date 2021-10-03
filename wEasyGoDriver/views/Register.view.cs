using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wEasyGoDriver.controls;


namespace wEasyGoDriver
{
    public partial class frmEasyGoDriver : Form
    {
        public frmEasyGoDriver()
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

    }
}
