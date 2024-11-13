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

namespace Library_Management_System
{
    public partial class EmployeeAuthors : Form
    {
        private static int id;
        public EmployeeAuthors()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel4.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel5.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void EmployeeAuthors_Load(object sender, EventArgs e)
        {

        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            if(txtFirstName.Text==" " && txtLastName.Text==" " && txtCountry.Text==" " )
            {
                MessageBox.Show("Kindlyy fill out all text boxes....");
            }
            else
            {
                string FirstName = txtFirstName.Text;
                string LastName = txtLastName.Text;
                string Country = txtCountry.Text;
                Author a = new Author(FirstName, LastName,Country);
                bool res = AuthorDL.AddAuthor(a);
                if(res==true)
                {
                    MessageBox.Show("Successfully Added...");
                    reloadUpdatedDatabase();
                }
            }
        }
        private void reloadUpdatedDatabase()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Author", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeAuthorsGV.DataSource = dt;
        }
        private void cmdShow_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Author", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeAuthorsGV.DataSource = dt;
        }

        private void EmployeeAuthorsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow r = EmployeeAuthorsGV.Rows[index];
            id = int.Parse(r.Cells[0].Value.ToString());

            txtFirstName.Text = r.Cells[1].Value + "";
            txtLastName.Text = r.Cells[2].Value + "";
            txtCountry.Text = int.Parse(r.Cells[3].Value.ToString()) + "";
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == " " && txtLastName.Text == " " && txtCountry.Text == " ")
            {
                MessageBox.Show("Kindlyy fill out all text boxes....");
            }
            else
            {
                string FirstName = txtFirstName.Text;
                string LastName = txtLastName.Text;
                string Country = txtCountry.Text;
                Author a = new Author(id,FirstName, LastName, Country);
                bool res = Author.EditAuthor(a);
                if (res == true)
                {
                    MessageBox.Show("Successfully Updated...");
                    reloadUpdatedDatabase();
                }
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                DataTable dt = new DataTable();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Author WHERE AuthorId LIKE '%" + id + "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                EmployeeAuthorsGV.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Select the Record you want to Search from table");
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
