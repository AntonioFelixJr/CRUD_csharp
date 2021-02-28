using CRUD.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.ShowDialog();
        }

        private void btnGerenciarProduto_Click(object sender, EventArgs e)
        {
            GerenciarProduto gerenciar = new GerenciarProduto();
            gerenciar.Show();
            this.Hide();
        }
    }
}
