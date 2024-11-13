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
using System.Text.RegularExpressions;

namespace Library_Management_System
{
    public partial class EmployeeGenre : Form
    {
        private int id;
        public EmployeeGenre()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel4.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel5.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void EmployeeGenre_Load(object sender, EventArgs e)
        {

        }
        private void reloadUpdatedDatabase()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Genre", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeGenreGV.DataSource = dt;
        }
        private void cmdInsert_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="")
            {
                bool res;
                Genre g = new Genre(txtName.Text);
                res=GenreDL.AddGenre(g);
                if(res==true)
                {
                    MessageBox.Show("Added Successfully...");
                }
            }
            else
            {
                MessageBox.Show("Fill out text box...");
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                bool res;
                Genre g = new Genre(id,txtName.Text);
                res = GenreDL.EditGenre(g);
                if (res == true)
                {
                    MessageBox.Show("Updated Successfully...");
                }
            }
            else
            {
                MessageBox.Show("Fill out text box...");
            }
        }

        private void EmployeeGenreGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow r = EmployeeGenreGV.Rows[index];
            id = int.Parse(r.Cells[0].Value.ToString());
            txtName.Text = r.Cells[1].Value + "";
          
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Genre", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeGenreGV.DataSource = dt;
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                DataTable dt = new DataTable();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Genre WHERE Id LIKE '%" + id + "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                EmployeeGenreGV.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Select the Record you want to Search from table");
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
