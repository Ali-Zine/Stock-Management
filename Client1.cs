using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StockApps
{
    public partial class Client1 : UserControl
    {
        Ado d = new Ado();
        int a;
        int b;

       
      
        public void remplirView()
        {
            d.Connecter();
            d.dt.Clear();
            d.com.CommandText = "Select * from Client";
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

        }
        public int nomber()
        {
            d.Connecter();
            int cpt;
            d.com.CommandText = "select count(CodeClient) from Client where CodeClient = '" + textBox1.Text + "'";
            d.com.Connection = d.con;
            cpt = (int)d.com.ExecuteScalar();
            return cpt;
            d.Deconnecter();
        }
        public bool AjouterClient()
        {
              if(nomber() == 0)
            {
                d.com.CommandText = "insert into Client values('"+textBox1.Text+"','" + textBox2.Text + "','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"') ";
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
                d.com.CommandText = "update Client set  Nom = '" + textBox2.Text + "', Prenom = '" + textBox3.Text + "', Adresse = '" + textBox4.Text + "', Tele = '" + textBox5.Text + "' where CodeClient = '"+textBox1.Text+"'";
                d.com.Connection = d.con;
                d.com.ExecuteNonQuery();
                return true;
            }
            return false;
        }
        public Client1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Merci to rempire tout les chemp");
                return;
            }
            if(AjouterClient() == true )
            {
                MessageBox.Show("Le Client est Ajouté");
                remplirView();
                vider();
            }
            else
            {
                MessageBox.Show("Le Client exist déja");
                vider();
            }
                
        }

        private void Client1_Load(object sender, EventArgs e)
        {
            d.Connecter();
            remplirView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0){
                DataGridViewRow Row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = Row.Cells["CodeClient"].Value.ToString();
                textBox2.Text = Row.Cells["Nom"].Value.ToString();
                textBox3.Text = Row.Cells["Prenom"].Value.ToString();
                textBox4.Text = Row.Cells["Adresse"].Value.ToString();
                textBox5.Text = Row.Cells["Tele"].Value.ToString();


            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Merci to rempire tout les chemp");
                return;
            }
            if (ModifferClient() == true)
            {
                MessageBox.Show("Le Client est Modifié");
                remplirView();
                vider();
            }
            else
            {
                MessageBox.Show("Le Client n'exist pas");
                vider();
            }

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            
            d.Connecter();
            d.com.CommandText = "Delete from Client where CodeClient ='" + textBox1.Text + "'";
            d.com.ExecuteNonQuery();
            remplirView();
            d.Deconnecter();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Remplier le Champ Code");
            }
            if(nomber() != 0)
            {
                d.dt.Clear();
                d.com.CommandText = "select * from Client where CodeClient = '" + textBox1.Text + "'";
                d.com.Connection = d.con;
                d.dr = d.com.ExecuteReader();
                d.dt.Load(d.dr);
                dataGridView1.DataSource = d.dt;
                d.dr.Close();
            }
            else
            {
                MessageBox.Show("Le Client n'exist pas");
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
