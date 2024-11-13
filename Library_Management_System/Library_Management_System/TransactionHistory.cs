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
    public partial class TransactionHistory : Form
    {
        public TransactionHistory()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void TransactionHistory_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataIntoGrid()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Transaction t Join Issuance i on t.IssunaceId = i.IssunaceId And StudentId = @UserId", con);
            cmd.Parameters.AddWithValue("@UserId", Login.UserId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            TransactionHistoryGV.DataSource = dt;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
