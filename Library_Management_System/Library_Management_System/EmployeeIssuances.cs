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
    public partial class EmployeeIssuances : Form
    {
        public static List<string> Books;

        public EmployeeIssuances()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow r = EmployeeIssuancesGV.Rows[index];
            int IssuanceId = int.Parse(r.Cells[0].Value.ToString());

            DateTime ReturnedDate = DateTime.Now;
            string sqlReturnedDate = ReturnedDate.ToString("yyyy-MM-dd HH:mm:ss");

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Book SET AvailableCopies = @AvailableCopies, status = @status WHERE IssuanceId = @IssuanceId", con);
            cmd.Parameters.AddWithValue("@ReturnedDate", SqlDbType.Date).Value = sqlReturnedDate;
            cmd.Parameters.AddWithValue("@Issuance", IssuanceId);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Information Updated");
            LoadDataIntoGrid();
        }

        private void EmployeeIssuances_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void cmdAddGenre_Click(object sender, EventArgs e)
        {
            
        }

        private void LoadDataIntoGrid()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * From Issuance i Join IssuanceDetails id where i.IssuanceId = id.IssuanceId Join Book b where id.BookId = b.BookID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeIssuancesGV.DataSource = dt;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
