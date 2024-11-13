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
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Library_Management_System
{
    public partial class Employees : Form
    {
        private int id;
        private int userid;
        public Employees()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel4.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel5.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            UserDL.LoadDataIntoComboBox(txtStatus);
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            bool res;
            if (txtEmail.Text == " " && txtName.Text == " " && txtUserName.Text == " " && txtPassword.Text == " " && txtPhoneNumber.Text == " " && txtRole.Text == " " && txtCity.Text == " " && txtCountry.Text == " " && txtAddress.Text == " " && txtStatus.Text == " ")
            {
                MessageBox.Show("Pleease Fill out all text boxes.....");
            }
            else
            {

                if (txtPhoneNumber.BackColor == Color.Green)
                {
                    if (Regex.IsMatch(txtEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == true)
                    {

                        var con = Configuration.getInstance().getConnection();

                        SqlCommand cmd1 = new SqlCommand("Select Username from Users where Username=@parm1 ", con);
                        cmd1.Parameters.AddWithValue("parm1", txtUserName.Text);
                        SqlDataReader reader1;
                        reader1 = cmd1.ExecuteReader();
                        if (reader1.Read())
                        {
                            MessageBox.Show("User with this Username number already exists..");
                            con.Close();
                        }
                        else
                        {
                            con.Close();

                            string Username = txtUserName.Text;
                            string Password = txtPassword.Text;
                            string Email = txtEmail.Text;
                            string Name = txtName.Text;
                            double Phone = double.Parse(txtPhoneNumber.Text);
                            string City = txtCity.Text;
                            string Country = txtCountry.Text;
                            string Address = txtAddress.Text;
                            string Status = txtStatus.Text;
                            int FloorId = int.Parse(txtFloorId.Text);
                            Role role = new Role(txtRole.Text, "USER_ROLE");
                            Librarian s = new Librarian(Username, Password, Email, role, Name, Phone, City, Country, Address, Status, FloorId);
                            {

                                res = UserDL.AddLibrarian(s);
                                if (res == true)
                                {
                                    MessageBox.Show("Added Successfully....");
                                }


                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Phone No.....");
                    }

                } }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            Regex r = new Regex(@"^[0-9]{10}$");
            if (r.IsMatch(txtPhoneNumber.Text))
            {
                txtPhoneNumber.BackColor = Color.Green;
            }
            else
            {
                txtPhoneNumber.BackColor = Color.Red;
            }
        }
        private void reloadUpdatedDatabase()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Librarian l Join  Users u on l.UserId=u.UserId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeesGV.DataSource = dt;
        }
        private void cmdShow_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Librarian l Join  Users u on l.UserId=u.UserId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeesGV.DataSource = dt;
        }

        private void EmployeesGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow r = EmployeesGV.Rows[index];
            id = int.Parse(r.Cells[0].Value.ToString());
            userid= int.Parse(r.Cells[1].Value.ToString());
            txtCity.Text = r.Cells[2].Value + "";
            txtCountry.Text = r.Cells[3].Value + "";
            txtAddress.Text = r.Cells[4].Value + "";
            txtFloorId.Text = (int.Parse(r.Cells[5].Value + "").ToString());
            txtStatus.Text = r.Cells[6].Value + "";
            userid = int.Parse(r.Cells[7].Value.ToString());
            txtUserName.Text = r.Cells[8].Value + "";
            txtPassword.Text = r.Cells[9].Value + "";
            txtEmail.Text = r.Cells[10].Value + "";
            txtRole.Text = r.Cells[11].Value + "";
            txtName.Text = r.Cells[12].Value + "";
            txtPhoneNumber.Text = r.Cells[13].Value + "";

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            bool res;
            if (txtEmail.Text == " " && txtName.Text == " " && txtUserName.Text == " " && txtPassword.Text == " " && txtPhoneNumber.Text == " " && txtRole.Text == " " && txtCity.Text == " " && txtCountry.Text == " " && txtAddress.Text == " " && txtStatus.Text == " ")
            {
                MessageBox.Show("Pleease Fill out all text boxes.....");
            }
            else
            {

                if (txtPhoneNumber.BackColor == Color.Green)
                {
                    if (Regex.IsMatch(txtEmail.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$") == true)
                    {


                        string Username = txtUserName.Text;
                        string Password = txtPassword.Text;
                        string Email = txtEmail.Text;
                        string Name = txtName.Text;
                        double Phone = double.Parse(txtPhoneNumber.Text);
                        string City = txtCity.Text;
                        string Country = txtCountry.Text;
                        string Address = txtAddress.Text;
                        string Status = txtStatus.Text;
                        int FloorId = int.Parse(txtFloorId.Text);
                        Role role = new Role(txtRole.Text, "USER_ROLE");
                        Librarian s = new Librarian(id,userid,Username, Password, Email, role, Name, Phone, City, Country, Address, Status, FloorId);
                        {

                            res = UserDL.EditLibrarian(s);
                            if (res == true)
                            {
                                MessageBox.Show("Updated Successfully....");
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Phone No.....");
                    }

                }
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                DataTable dt = new DataTable();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Librarian WHERE LibrarianId LIKE '%" + id + "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                EmployeesGV.DataSource = dt;
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

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
