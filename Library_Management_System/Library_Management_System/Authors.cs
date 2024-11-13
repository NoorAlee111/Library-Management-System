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
    public partial class Authors : Form
    {
        public Authors()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void Authors_Load(object sender, EventArgs e)
        {
            LoadDataIntoGrid();
        }

        private void AuthorsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadDataIntoGrid()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Author", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            AuthorsGV.DataSource = dt;
        }
    }
}
