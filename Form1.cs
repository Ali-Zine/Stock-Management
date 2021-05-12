using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockApps
{
    public partial class Form1 : Form
    {
        Ado d = new Ado();
        public Form1()
        {
            InitializeComponent();
            client11.BringToFront();
            fournisseur1.BringToFront();
            welcome1.BringToFront();


        }
     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            welcome1.BringToFront();
            d.Connecter();


        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            client11.BringToFront();

        }


        private void client11_Load(object sender, EventArgs e)
        {
         
        }

        private void welcome1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            fournisseur1.BringToFront();
            d.Connecter();
        }
    }
}
