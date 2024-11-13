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
using Library_Management_System.BL;
using System.Text.RegularExpressions;
using Library_Management_System.DL;

namespace Library_Management_System
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(175, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);

        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            UserDL.LoadDataIntoUserComboBox(txtRole);
            UserDL.LoadDataIntoAdministratorComboBox(txtRole);
        }

        private void cmdCreateAccount_Click(object sender, EventArgs e)
        {
            bool res;
            if(txtEmail.Text==" " && txtName.Text == " " && txtUserName.Text == " " && txtPassword.Text == " " && txtConfirmPassword.Text == " " && txtPhoneNumber.Text == " " && txtRole.Text == " " && txtId.Text == " ")
            {
                MessageBox.Show("Pleease Fill out all text boxes.....");
            }
            else
            {

                if(txtPassword.Text == txtConfirmPassword.Text)
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
                                if (txtRole.Text == "Student")
                                {
                                    string Username = txtUserName.Text;
                                    string Password = txtPassword.Text;
                                    string Email = txtEmail.Text;
                                    string Name = txtName.Text;
                                    double Phone = double.Parse(txtPhoneNumber.Text);
                                    string RollNo = txtId.Text;
                                    Role role = new Role(txtRole.Text, "USER_ROLE");
                                    Student s = new Student(Username, Password, Email, role, Name, Phone, RollNo);
                                    res = UserDL.AddStudent(s);
                                    if (res == true)
                                    {
                                        MessageBox.Show("User Added Successfully....");
                                    }
                                }
                                else
                                {
                                    string Username = txtUserName.Text;
                                    string Password = txtPassword.Text;
                                    string Email = txtEmail.Text;
                                    string Name = txtName.Text;
                                    double Phone = double.Parse(txtPhoneNumber.Text);
                                    string Position = txtId.Text;
                                    Role role = new Role(txtRole.Text, "USER_ROLE");
                                    if (Position == "Head" || Position == "Manager")
                                    {

                                        Administrator a = new Administrator(Username, Password, Email, role, Name, Phone, Position);
                                        res = UserDL.AddAdministrator(a);
                                        if (res == true)
                                        {
                                            MessageBox.Show("User Added Successfully....");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Enter correct Position.....");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Phone No.....");
                    }
                }
                else
                {
                    txtPassword.BackColor = Color.Red;
                    MessageBox.Show("Password does not match.....");
                }
            }
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
          
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
