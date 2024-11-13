using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Author
    {
        private int AuthorID;
        private string FirstName;
        private string LastName;
        private string Country;

        public int AuthorID1 { get => AuthorID; set => AuthorID = value; }
        public string FirstName1 { get => FirstName; set => FirstName = value; }
        public string LastName1 { get => LastName; set => LastName = value; }
        public string Country1 { get => Country; set => Country = value; }

        public Author()
        {

        }

        public Author(int AuthorID, string FirstName, string LastName, string Country) // with ID
        {
            this.AuthorID = AuthorID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Country = Country;
        }

        public Author( string FirstName, string LastName, string Country) // without ID
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Country = Country;
        }
        public static bool EditAuthor(Author a)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE  Author SET FirstName = @FirstName, LastName = @LastName, Country = @Country WHERE AuthorId = @AuthorId", con);
            cmd.Parameters.AddWithValue("@AuthorId", a.AuthorID1);
            cmd.Parameters.AddWithValue("@FirstName", a.FirstName1);
            cmd.Parameters.AddWithValue("@LastName", a.LastName1);
            cmd.Parameters.AddWithValue("@Country", a.Country1);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
