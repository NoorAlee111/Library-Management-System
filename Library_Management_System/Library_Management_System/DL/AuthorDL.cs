using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Library_Management_System.BL;
using Library_Management_System.DL;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System.DL
{
    public class AuthorDL
    {
        public static bool AddAuthor(Author a)
        {
            var con = Configuration.getInstance().getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Author (FirstName, LastName, Country) VALUES (@FirstName, @LastName, @ Country);", con);
            cmd.Parameters.AddWithValue("@FirstName",a.FirstName1);
            cmd.Parameters.AddWithValue("@LastName", a.LastName1);
            cmd.Parameters.AddWithValue("@Country", a.Country1);
            cmd.ExecuteNonQuery();
            return true;
            
        }
        
       

       // public static void DeleteAuthor()
        //{

        //}

        public static void SearchAuthor()
        {

        }

        public static void LoadAuthors()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Author", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }

        public static void StoreAuthors()
        {

        }
    }
}
