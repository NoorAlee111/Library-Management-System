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
    public partial class EmployeeTransactions : Form
    {
        public EmployeeTransactions()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void EmployeeTransactions_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            DateTime CurrentDate = DateTime.Now;
            string sqlCurrentDate = CurrentDate.ToString("yyyy-MM-dd HH:mm:ss");

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("INSERT INTO Transaction (IssuanceId, Fine) SELECT IssuanceId, DATEDIFF(day, DueDate, @CurrentDate) * 500 AS Fine FROM Issuance WHERE DueDate < @CurrentDate And ReturnDate Is NULL", con);
            cmd.Parameters.AddWithValue("@CurrentDate", SqlDbType.Date).Value = sqlCurrentDate;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeTransactionsGV.DataSource = dt;
        }

        private void EmployeeTransactionsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
