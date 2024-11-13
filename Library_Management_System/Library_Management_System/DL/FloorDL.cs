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
    public class FloorDL
    {
        static int getFloorId()
        {
            string queryString = "SELECT FloorId FROM Floors ORDER BY FloorId DESC LIMIT 1;";
            var con = Configuration.getInstance().getConnection();
            using (SqlCommand cmd1 = new SqlCommand(queryString, con))
            {
                // Execute the query and get the result
                int result = (int)cmd1.ExecuteScalar();

                // Save the result in a variable
                int myVariable = result;
                return myVariable;
            }

        }
        static void AddFloorGenre(Floor f)
        {

            foreach (Genre a in f.Genres1)
            {
                var con1 = Configuration.getInstance().getConnection();
                con1.Open();
                SqlCommand cmd = new SqlCommand("Insert into FloorsGenre(FloorId,GenreId) VALUES  (@FloorId,@GenreId)", con1);
                cmd.Parameters.AddWithValue("@FloorId", f.FloorID1);
                cmd.Parameters.AddWithValue("@GenreId", a.GenreID1);
                cmd.ExecuteNonQuery();
                con1.Close();
            }
        }
        public static bool AddFloor(Floor f)
        {
          
            var con1 = Configuration.getInstance().getConnection();
            con1.Open();
            SqlCommand cmd = new SqlCommand("Insert into Floors(FloorNo) values (@FloorNo);", con1);
            cmd.Parameters.AddWithValue("@FloorNo", f.Number1);
            cmd.ExecuteNonQuery();
            int id = getFloorId();
            Floor f2 = new Floor(id, f.Number1, f.Genres1);
            AddFloorGenre(f2);
            return true;
        }

        public static bool EditFloor(Floor f)
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE  Floors SET FloorNo= @FloorNo WHERE FloorId = @FloorId", con);
            cmd.Parameters.AddWithValue("@FloorId", f.FloorID1);
            cmd.Parameters.AddWithValue("@FloorNo", f.Number1);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static void DeleteFloor()
        {

        }

        //public static Floor SearchFloor()
        //{

        //}

        public static void LoadFloors()
        {

        }

        public static void StoreFloors()
        {

        }

        public static void LoadDataIntoGenreComboBox(ComboBox txtGenre)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT GenreName FROM Genre", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                txtGenre.Items.Add(r["GenreName"].ToString());
            }
        }
    }
}
