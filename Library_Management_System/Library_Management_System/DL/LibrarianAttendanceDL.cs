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
    public class LibrarianAttendanceDL
    {
        public static void AddLibrarianAttendance()
        {

        }

        public static void EditLibrarianAttendance()
        {

        }

        public static void DeleteLibrarianAttendance()
        {

        }

        //public static LibrarianAttendance SearchLibrarianAttendance()
        //{

        //}

        public static void LoadLibrarianAttendance()
        {

        }

        public static void StoreLibrarianAttendance()
        {

        }

        public static void LoadDataIntoComboBox(DataGridViewComboBoxColumn txtStatus)
        {
            string Category = "ATTENDANCE_STATUS";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Status WHERE Category = @Category", con);
            cmd.Parameters.AddWithValue("@Category", Category);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                txtStatus.Items.Add(r["Name"].ToString());
            }
        }
    }
}
