using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.BL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System.DL
{
    public class UserDL
    {
        static  int getuserid()
          {
            string queryString = "SELECT Top 1 UserId FROM Users ORDER BY UserId DESC ;";
            var con = Configuration.getInstance().getConnection();
            using (SqlCommand cmd1 = new SqlCommand(queryString, con)) 
            {
                // Execute the query and get the result
                int result = (int)cmd1.ExecuteScalar();

                // Save the result in a variable
                int myVariable = result;
                return myVariable;
            }
            
        }
        public static bool AddStudent(Student s)
        {

            var con = Configuration.getInstance().getConnection();

            SqlCommand cmd1 = new SqlCommand("Select RollNumber from Student where RollNumber=@parm1 ", con);
            cmd1.Parameters.AddWithValue("parm1", s.RollNo1);
            SqlDataReader reader1;
            con.Open();
            reader1 = cmd1.ExecuteReader();
            
            if (reader1.Read())
            {
                MessageBox.Show("Student with this Registrartion number already exists..");
                con.Close();
            }
            else
            {
                con.Close();
                User u = new User(s.Username1, s.Password1, s.Email1, s.Role1, s.Name1, s.Phone1);
                AddUser(u);
                int userid = UserDL.getuserid();
                var con1 = Configuration.getInstance().getConnection();
                
                SqlCommand cmd = new SqlCommand("Insert into Student(UserId,RollNumber) VALUES  (@UserId,@RollNumber)", con1);
                cmd.Parameters.AddWithValue("@RollNumber", s.RollNo1);
                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.ExecuteNonQuery();
                

                return true;
            }
            return false;

        }
        public static bool AddAdministrator(Administrator s)
        {
                User u = new User(s.Username1, s.Password1, s.Email1, s.Role1, s.Name1, s.Phone1);
                AddUser(u);
                var con1 = Configuration.getInstance().getConnection();
                con1.Open();
                int userid = UserDL.getuserid();
                 SqlCommand cmd = new SqlCommand("Insert into Administrator(UserId,String) values (@UserId,@String);", con1);
                cmd.Parameters.AddWithValue("@String", s.Position1);
                 cmd.Parameters.AddWithValue("@UserId", userid);
                 cmd.ExecuteNonQuery();
               
                return true;
       
        }
        public static bool AddLibrarian(Librarian s)
        {
            User u = new User(s.Username1, s.Password1, s.Email1, s.Role1, s.Name1, s.Phone1);
            AddUser(u);
            var con1 = Configuration.getInstance().getConnection();
            con1.Open();
            int userid = UserDL.getuserid();
            SqlCommand cmd = new SqlCommand("EXEC usp_InsertLibrarian @UserId, @City, @Country, @Address, @FloorId, @Status", con1);
            cmd.Parameters.AddWithValue("@UserId", userid);
            cmd.Parameters.AddWithValue("@City", s.City1);
            cmd.Parameters.AddWithValue("@Country", s.Country1);
            cmd.Parameters.AddWithValue("@Address", s.Address1);
            cmd.Parameters.AddWithValue("@Address", s.Address1);
            cmd.Parameters.AddWithValue("@FloorId", s.FloorId1);
            cmd.Parameters.AddWithValue("@Status", s.Status1);
            cmd.ExecuteNonQuery();

            return true;

        }

        public static void AddUser(User u)
        {
            var con1 = Configuration.getInstance().getConnection();
            con1.Open();
            SqlCommand cmd = new SqlCommand("Insert into Users(Username,Password,Email,Role,Name,Phone) values (@Username,@Password,@Email,@Role,@Name,@Phone)", con1);
            cmd.Parameters.AddWithValue("@UserName", u.Username1);
            cmd.Parameters.AddWithValue("@Password", u.Password1);
            cmd.Parameters.AddWithValue("@Email", u.Email1);
            cmd.Parameters.AddWithValue("@Role", u.Role1.Name1);
            cmd.Parameters.AddWithValue("@Name", u.Name1);
            cmd.Parameters.AddWithValue("@Phone", u.Phone1);
            cmd.ExecuteNonQuery();
        }
        public static bool EditLibrarian(Librarian s)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC usp_UpdateLibrarian @UserId, @City, @Country, @Address, @FloorId, @Status", con);

            cmd.Parameters.AddWithValue("@LibrarianId", s.LibrarianId1);
            cmd.Parameters.AddWithValue("@UserId", s.UserID1);
            cmd.Parameters.AddWithValue("@City", s.City1);
            cmd.Parameters.AddWithValue("@Country", s.Country1);
            cmd.Parameters.AddWithValue("@Address", s.Address1);
            cmd.Parameters.AddWithValue("@FloorId", s.FloorId1);
            cmd.Parameters.AddWithValue("@Status", s.Status1);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static void DeleteUser()
        {

        }

        //public static User SearchUser()
        //{

        //}

        public static void LoadUsers()
        {

        }

        public static void StoreUsers()
        {

        }

        public static void LoadDataIntoComboBox(ComboBox txtStatus)
        {
            string Category = "LIBRARIAN_STATUS";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Status WHERE Category = @Category", con);
            cmd.Parameters.AddWithValue("@Category", Category);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                txtStatus.Items.Add(r["Name"].ToString());
            }
        }

        public static void LoadDataIntoUserComboBox(ComboBox txtRole)
        {
            string Category = "USER_ROLE";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Role WHERE Category = @Category AND Name <> 'Librarian'  AND Name <> 'Administrator'", con);
            cmd.Parameters.AddWithValue("@Category", Category);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                txtRole.Items.Add(r["Name"].ToString());
            }
        }

        public static void LoadDataIntoAdministratorComboBox(ComboBox txtRole)
        {
            string Category = "ADMINISTRATOR_ROLE";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Name FROM Role WHERE Category = @Category", con);
            cmd.Parameters.AddWithValue("@Category", Category);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                txtRole.Items.Add(r["Name"].ToString());
            }
        }
    }
}
