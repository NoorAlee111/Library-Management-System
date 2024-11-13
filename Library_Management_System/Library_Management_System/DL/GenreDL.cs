using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.BL;
using System.Data.SqlClient;

namespace Library_Management_System.DL
{
    public class GenreDL
    {
        public static bool AddGenre(Genre g)
        {
            var con1 = Configuration.getInstance().getConnection();
            con1.Open();
            SqlCommand cmd = new SqlCommand("EXEC usp_InsertGenre  @GenreName", con1);
            cmd.Parameters.AddWithValue("@GenreName", g.GenreID1);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static bool EditGenre(Genre g)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC usp_UpdateGenre  @Id, @GenreName", con);
            cmd.Parameters.AddWithValue("@Id", g.GenreID1);
            cmd.Parameters.AddWithValue("@GenreName", g.GenreID1);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static void DeleteGenre()
        {

        }

        //public static Genre SearchGenre()
        //{

        //}

        public static void LoadGenres()
        {

        }

        public static void StoreGenres()
        {

        }
    }
}
