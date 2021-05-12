using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StockApps
{
    class Ado
    {
        //---------------------- Declaration des objets SQL -----------------
            
        public SqlConnection con = new SqlConnection(); // connect de base donnes
        public SqlCommand com = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();
      
        //-------------------- Declaration de la Methode Connecter ---------------------

        public void Connecter()
        {
            if(con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = "Data Source=ZABOZA;Initial Catalog=GestionStock;Integrated Security=True";
                con.Open();
            }
        }

        //--------------------- Declaration de la Methode Deconnecte --------------------
       public void Deconnecter()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

}
