using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockApps
{
    public partial class Fournisseur : UserControl
    {
        Ado d = new Ado();

        public void remplirView()
        {
            d.Connecter();
            d.dt.Clear();
            d.com.CommandText = "Select * from Fournisseur";
            d.com.Connection = d.con;
            d.dr = d.com.ExecuteReader();
            d.dt.Load(d.dr);
            dataGridView1.DataSource = d.dt;
            d.dr.Close();
        }
        public void vider()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }
        public int nomber()
        {
            int cpt;
            d.com.CommandText = "select count(CodeFour) from Fournisseur where CodeFour = '" + textBox1.Text + "'";
            d.com.Connection = d.con;
            cpt = (int)d.com.ExecuteScalar();
            return cpt;
        }
        public bool AjouterClient()
        {
            if (nomber() == 0)
            {
                d.com.CommandText = "insert into Fournisseur values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text +"') ";
                d.com.Connection = d.con;
                d.com.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        public bool ModifferClient()
        {
            if (nomber() != 0)
            {
                d.com.CommandText = "update Fournisseur set  Nom = '" + textBox2.Text + "', Prenom = '" + textBox3.Text + "', Adresse = '" + textBox4.Text + "', Tele = '" + textBox5.Text + "', Fax = '"+textBox6.Text+"' where CodeFour = '" + textBox1.Text + "'";
                d.com.Connection = d.con;
                d.com.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public bool SupprimesClient()
        {
            if (nomber() != 0)
            {
                d.com.CommandText = "delete from Fournisseur where CodeFour = '" + textBox1.Text + "'";
                d.com.Connection = d.con;
                d.com.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        public Fournisseur()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Merci to rempire tout les chemp");
                return;
            }
            if (AjouterClient() == true)
            {
                MessageBox.Show("Le Fournisseur est Ajouté");
                remplirView();
                vider();
            }
            else
            {
                MessageBox.Show("Le Fournisseur exist déja");
                vider();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Merci to rempire tout les chemp");
                return;
            }
            if (ModifferClient() == true)
            {
                MessageBox.Show("Le Fournisseur est Modifié");
                remplirView();
                vider();
            }
            else
            {
                MessageBox.Show("Le Fournisseur n'exist pas");
                vider();
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Supprimer le Fournisseur", "Confirmatiob", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            
                if (SupprimesClient() == true) // Le Stagaire est Suppreme dan La base Donne "Return True"
                {
                    MessageBox.Show("Le Fournisseur est Supprimer");
                    remplirView();
                    vider();
                }
                else // Le Stagaire Exist Deja on Base Donnes "Return False"
                {
                    MessageBox.Show("Le Fournisseur n'exist pas ");
                    vider();
                }
            }
            else
            {
                return;
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Remplier le Champ Code");
            }
            if (nomber() != 0)
            {
                d.dt.Clear();
                d.com.CommandText = "select * from Fournisseur where CodeFour = '" + textBox1.Text + "'";
                d.com.Connection = d.con;
                d.dr = d.com.ExecuteReader();
                d.dt.Load(d.dr);
                dataGridView1.DataSource = d.dt;
                d.dr.Close();
            }
            else
            {
                MessageBox.Show("Le Fournisseur n'exist pas");
            }
        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {
            d.Connecter();
            remplirView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                DataGridViewRow Row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = Row.Cells["CodeFour"].Value.ToString();
                textBox2.Text = Row.Cells["Nom"].Value.ToString();
                textBox3.Text = Row.Cells["Prenom"].Value.ToString();
                textBox4.Text = Row.Cells["Adresse"].Value.ToString();
                textBox5.Text = Row.Cells["Tele"].Value.ToString();
                textBox6.Text = Row.Cells["Fax"].Value.ToString();
            }
        }
    }
}
