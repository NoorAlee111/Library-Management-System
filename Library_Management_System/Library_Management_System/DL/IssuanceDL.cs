using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.BL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System.DL
{
    public class IssuanceDL
    {
        public static void AddIssuance()
        {

        }

        public static void EditIssuance()
        {

        }

        public static void DeleteIssuance()
        {

        }

        //public static Issuance SearchIssuance()
        //{

        //}

        public static void LoadIssuances()
        {

        }

        public static void StoreIssuances()
        {

        }

        public static void LoadDataIntoBookComboBox(ComboBox txtAuthor)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Title FROM Book", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                txtAuthor.Items.Add(r["Title"].ToString());
            }
        }
    }
}
