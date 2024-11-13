using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            string status = "Available";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Book where status = @status", con);
            cmd.Parameters.AddWithValue("@status", status);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            IssueBooksGV.DataSource = dt;
        }

        private void IssueBooksGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow r = IssueBooksGV.Rows[index];
            int BookId = int.Parse(r.Cells[0].Value.ToString());
            int AvailableCopies = int.Parse(r.Cells[5].Value.ToString());
            string status;
            if (AvailableCopies != 0)
            {
                AvailableCopies = AvailableCopies - 1;
            }
            if (AvailableCopies == 0)
            {
                status = "UnAvailable";
            }
            else
            {
                status = "Available";
            }

            int UserId = Login.UserId;
             
            UpdateAvailaleCopies(BookId, AvailableCopies, status);
            InsertIntoIssuanceTable(UserId);
            InsertIntoIssuanceDetailsTable(BookId);
        }

        private void UpdateAvailaleCopies(int BookId, int AvailableCopies, string status)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Book SET AvailableCopies = @AvailableCopies, status = @status WHERE BookID = @BookId", con);
            cmd.Parameters.AddWithValue("@BookId", BookId);
            cmd.Parameters.AddWithValue("@AvailableCopies", AvailableCopies);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Information Updated");
            LoadDataIntoGrid();
        }

        private void InsertIntoIssuanceTable(int UserId)
        {
            DateTime IssuanceDate = DateTime.Now;
            string sqlIssuanceDate = IssuanceDate.ToString("yyyy-MM-dd HH:mm:ss");

            DateTime DueDate = IssuanceDate.AddDays(10);
            string sqlDueDate = DueDate.ToString("yyyy-MM-dd HH:mm:ss");

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Issuance (StudentId, IssuanceDate, DueDate) VALUES (@UserId, @IssuanceDate, @DueDate);", con);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@IssunaceDate", SqlDbType.Date).Value = sqlIssuanceDate;
            cmd.Parameters.AddWithValue("@DueDate", SqlDbType.Date).Value = sqlDueDate;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Issused");
        }

        private void InsertIntoIssuanceDetailsTable(int BookId)
        {
            int IssuanceId = 0;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 IssuanceId * FROM Issuance ORDER BY d DESC;", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                IssuanceId = reader.GetInt32(0);
                reader.Close();
            }

            var con1 = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO Issuance (IssuanceId, BookId) VALUES (@IssuanceId, @BookId);", con1);
            cmd1.Parameters.AddWithValue("@IssuanceId", IssuanceId);
            cmd1.Parameters.AddWithValue("@BookId", BookId);
            cmd1.ExecuteNonQuery();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
