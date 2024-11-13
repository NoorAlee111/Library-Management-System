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

namespace Library_Management_System.DL
{
 
    public class BookDL
    {
      static  void AddintoBookAuthors(int bookid, Book b)
        {
            foreach (Author a in b.Author1)
            {
                var con1 = Configuration.getInstance().getConnection();
                con1.Open();
                SqlCommand cmd = new SqlCommand("Insert into BookAuthorDetails(BookID,AuthorId) VALUES  (@BookID,@AuthorId)", con1);
                cmd.Parameters.AddWithValue("@BookID", bookid);
                cmd.Parameters.AddWithValue("@AuthorId", a.AuthorID1);
                cmd.ExecuteNonQuery();
                con1.Close();
            }
        }
        static void AddintoBookGenre(int bookid, Book b)
        {
            foreach (Genre a in b.Genre1)
            {
                var con1 = Configuration.getInstance().getConnection();
                con1.Open();
                SqlCommand cmd = new SqlCommand("Insert into BookGenre(BookID,GenreId) VALUES  (@BookID,@GenreId)", con1);
                cmd.Parameters.AddWithValue("@BookID", bookid);
                cmd.Parameters.AddWithValue("@GenreId", a.GenreID1);
                cmd.ExecuteNonQuery();
                con1.Close();
            }
        }
        static int getbookid()
        {
            string queryString = "SELECT BookID FROM Book ORDER BY UserId DESC LIMIT 1;";
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
        public static bool AddBook(Book b)
        {
            var con1 = Configuration.getInstance().getConnection();
            con1.Open();
            SqlCommand cmd = new SqlCommand("EXEC usp_InsertBook @Title, @YearPublished, @TotalCopies, @AvaliableCopies, @status", con1);
            cmd.Parameters.AddWithValue("@Title", b.Title1);
            cmd.Parameters.AddWithValue("@YearPublished", b.YearPublished1);
            cmd.Parameters.AddWithValue("@TotalCopies", b.TotalCopies1);
            cmd.Parameters.AddWithValue("@AvaliableCopies", b.AvailableCopies1);
            cmd.Parameters.AddWithValue("@status", b.Status1);
            cmd.ExecuteNonQuery();
            int bookid = getbookid();
            AddintoBookAuthors(bookid,b);
            AddintoBookGenre(bookid, b);
            return true;

        }
       
        public static bool EditBook(Book b)
        {
            var con1 = Configuration.getInstance().getConnection();
            con1.Open();
            SqlCommand cmd = new SqlCommand("EXEC asp_UpdateBook @BookID, @Title, @YearPublished, @TotalCopies, @AvaliableCopies, @status", con1);
            cmd.Parameters.AddWithValue("@BookID", b.BookID1);
            cmd.Parameters.AddWithValue("@Title", b.Title1);
            cmd.Parameters.AddWithValue("@YearPublished", b.YearPublished1);
            cmd.Parameters.AddWithValue("@TotalCopies", b.TotalCopies1);
            cmd.Parameters.AddWithValue("@AvaliableCopies", b.AvailableCopies1);
            cmd.Parameters.AddWithValue("@status", b.Status1);
            cmd.ExecuteNonQuery();
            return true;
        }

        public static void DeleteBook()
        {

        }

        /*public static Book SearchBook()
        {

        }*/

        public static void LoadBooks()
        {

        }

        public static void StoreBooks()
        {

        }


        public static void LoadDataIntoComboBox(ComboBox txtStatus)
        {
            string Category = "BOOK_STATUS";
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

        public static void LoadDataIntoAuthorComboBox(ComboBox txtAuthor)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT FirstName FROM Author", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                txtAuthor.Items.Add(r["FirstName"].ToString());
            }
        }

        public static void LoadDataIntoGenreComboBox(ComboBox txtGenre)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT GenreName FROM Genre", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                txtGenre.Items.Add(r["GenreName"].ToString());
            }
        }
    }
}
