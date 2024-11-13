using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_Management_System.DL;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel4.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            LibrarianAttendanceDL.LoadDataIntoComboBox(txtStatus);
        }

        private void LoadDate()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select LibrarianId, UserId, Name from Librarian Where Status = 'Active'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AttendanceGV.DataSource = dt;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AttendanceGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdMarkAttendance_Click(object sender, EventArgs e)
        {
            if (Date != null)
            {
                var con = Configuration.getInstance().getConnection();
                DateTime date = Date.Value;
                SqlCommand cmd = new SqlCommand("Insert into StaffAttendance values (@date)", con);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.ExecuteNonQuery();

                int AttendanceId = 0;
                var con2 = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand("Select Id from StaffAttendance Where YEAR(AttendanceDate) = @Year1 AND MONTH(AttendanceDate) = @Month AND Day(AttendanceDate) = @Day", con2);
                cmd2.Parameters.AddWithValue("@Year1", date.Year);
                cmd2.Parameters.AddWithValue("@Month", date.Month);
                cmd2.Parameters.AddWithValue("@Day", date.Day);
                SqlDataReader reader = cmd2.ExecuteReader();
                if (reader.Read())
                {
                    AttendanceId = reader.GetInt32(0);
                    reader.Close();
                }

                for (int i = 0; i < AttendanceGV.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = AttendanceGV.Rows[i];
                    int UserId = int.Parse(row.Cells[1].Value.ToString());
                    DataGridViewComboBoxCell cell0 = row.Cells[0] as DataGridViewComboBoxCell;
                    int Status = int.Parse(cell0.Value.ToString());


                    var con3 = Configuration.getInstance().getConnection();
                    SqlCommand cmd3 = new SqlCommand("Insert into LibrarianAttendance values (@AttendanceId, @UserId, @Status)", con3);
                    cmd3.Parameters.AddWithValue("@AttendanceId", AttendanceId);
                    cmd3.Parameters.AddWithValue("@UserId", UserId);
                    cmd3.Parameters.AddWithValue("@Status", Status);
                    cmd3.ExecuteNonQuery();
                }

                MessageBox.Show("Attendance Marked Successfully");

            }
            else
            {
                MessageBox.Show("Please fill in the Date Text Box");
            }
        }
    }
}
