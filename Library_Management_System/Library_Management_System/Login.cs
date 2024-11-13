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
    public partial class Login : Form
    {
        public static int UserId;

        public Login()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(175, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text;
            string Password = txtPassword.Text;
            if(UserName!="" && Password!="")
            {
               
                    var con = Configuration.getInstance().getConnection();
                    string role = "";
                    SqlCommand cmd = new SqlCommand("SELECT Count(*), Role FROM Users WHERE Username=@Username AND Password=@Password GROUP BY Role", con);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Password",Password );
                  int count = 0;
                  using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                        role = reader.GetString(1);
                    }
                }
                if (count > 0)
                {
                    MessageBox.Show("You have successfully signed in with role: " + role);

                    // Allow or deny access to the application based on the user's role
                    if (role == "Librarian")
                    {
                        EmployeesHome f = new EmployeesHome();
                        f.Show();
                    }
                    else if (role == "Administrator" || role == "Head" || role == "Manager")
                    {
                        AdministratorHome f = new AdministratorHome();
                        f.Show();
                    }
                    else if (role == "Student")
                    {
                        StudentsHome f = new StudentsHome();
                        f.Show();
                    }
                    else
                    {
                        // Role not recognized, deny access
                        MessageBox.Show(" Role not recognized, deny access.....");
                    }
                }
                else
                {
                    MessageBox.Show("No such user exists in system.....");
                }


            }

            
        }

        private void GetUserId(String UserName)
        {
            int UserId = 0;
            var con2 = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Select Id from Users Where Username = @UserName", con2);
            cmd2.Parameters.AddWithValue("@Username", UserName);
            SqlDataReader reader = cmd2.ExecuteReader();
            if (reader.Read())
            {
                UserId = reader.GetInt32(0);
                reader.Close();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
