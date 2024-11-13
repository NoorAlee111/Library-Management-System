using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library_Management_System.BL;
using Library_Management_System.DL;

namespace Library_Management_System
{
    public partial class EmployeeBooks : Form
    {

        public static List<Author> Authors;
        public static List<Genre> Genres;
        private int id;
        bool res;

        public EmployeeBooks()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel4.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel5.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void EmployeeBooks_Load(object sender, EventArgs e)
        {
            BookDL.LoadDataIntoComboBox(txtStatus);
            BookDL.LoadDataIntoAuthorComboBox(txtAuthor);
            BookDL.LoadDataIntoGenreComboBox(txtGenre);
        }
        Genre getGenreObject(string Name)
        {
            Genre g = new Genre(); ;
            var con = Configuration.getInstance().getConnection();
            using (SqlCommand command = new SqlCommand("SELECT GenreName FROM Genre where GenreName=@GenreName", con))
            {
                command.Parameters.AddWithValue("@GenreName", Name);
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int Genreid = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        g = new Genre(Genreid, name);
                        return g;
                    }
                    else
                    {
                        // Handle the case where there is no data returned
                        MessageBox.Show("No such record..exists...");
                    }
                }
            }
            return g;

        }
        Author getAuthorObject(string Name)
        {
            Author g = new Author();
            var con = Configuration.getInstance().getConnection();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Author where FirstName=@FirstName", con))
            {
                command.Parameters.AddWithValue("@FirstName", Name);
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int Authorid = reader.GetInt32(0);
                        string Firstname = reader.GetString(1);
                        string Lastname = reader.GetString(2);
                        string Country = reader.GetString(3);
                        g = new Author(Authorid, Firstname, Lastname, Country);
                        return g;
                    }
                    else
                    {
                        // Handle the case where there is no data returned
                        MessageBox.Show("No such record..exists...");
                    }
                }
            }
            return g;

        }
        private void reloadUpdatedDatabase()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Book", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeBooksGV.DataSource = dt;
        }
        private void txtStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmdAddAuthor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAuthor.Text))
            {
                Author g = getAuthorObject(txtAuthor.Text);
                Authors.Append(g);
                txtAuthor.Text = null;
            }
            else
            {
                MessageBox.Show("Combo Box is Empty");
            }
        }

        private void cmdAddGenre_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGenre.Text))
            {

                Genre g = getGenreObject(txtGenre.Text);
                Genres.Append(g);
                txtGenre.Text = null;
            }
            else
            {
                MessageBox.Show("Combo Box is Empty");
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtAuthor.Text == "" && Authors.Count == 0 && txtGenre.Text == "" && Genres.Count == 0 && txtYearPublished.Text == "" && txtAvailableCopies.Text == "" && txtStatus.Text == "")
            {
                MessageBox.Show("Please fill out all text boxes....");
            }
            else
            {
                string Title = txtName.Text;
                int YearPublished = int.Parse(txtYearPublished.Text);
                int AvailableCopies = int.Parse(txtAvailableCopies.Text);
                int TotalCopies = int.Parse(txtCopies.Text);
                string Status = txtStatus.Text;


                if (txtAuthor.Text == "" && Authors.Count != 0)
                {
                    if (txtGenre.Text == "" && Genres.Count != 0)
                    {
                        Book b = new Book(Title, YearPublished, TotalCopies, AvailableCopies, Status, Authors, Genres);
                        res = BookDL.AddBook(b);
                        if (res == true)
                        {
                            MessageBox.Show("Successfully saved...");
                        }
                    }
                    else if (txtGenre.Text != "")
                    {
                        Genre g = getGenreObject(txtGenre.Text);
                        Genres.Add(g);
                        Book b = new Book(Title, YearPublished, TotalCopies, AvailableCopies, Status, Authors, Genres);

                        res = BookDL.AddBook(b);
                        if (res == true)
                        {
                            MessageBox.Show("Successfully saved...");
                        }
                    }

                }
                else
                {
                    Author a = getAuthorObject(txtGenre.Text);
                    Authors.Add(a);
                    if (txtGenre.Text == "" && Genres.Count != 0)
                    {
                        Book b = new Book(Title, YearPublished, TotalCopies, AvailableCopies, Status, Authors, Genres);
                        res = BookDL.AddBook(b);
                        if (res == true)
                        {
                            MessageBox.Show("Successfully saved...");
                        }
                    }
                    else if (txtGenre.Text != "")
                    {
                        Genre g = getGenreObject(txtGenre.Text);
                        Genres.Add(g);
                        Book b = new Book(Title, YearPublished, TotalCopies, AvailableCopies, Status, Authors, Genres);
                        res = BookDL.AddBook(b);
                        if (res == true)
                        {
                            MessageBox.Show("Successfully saved...");
                        }
                    }
                }
            }
        }

        private void EmployeeBooksGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow r = EmployeeBooksGV.Rows[index];
            id = int.Parse(r.Cells[0].Value.ToString());
            txtName.Text = r.Cells[1].Value + "";
            txtYearPublished.Text = r.Cells[2].Value + "";
            txtCopies.Text = r.Cells[3].Value + "";
            txtAvailableCopies.Text = r.Cells[4].Value + "";
            txtStatus.Text = r.Cells[5].Value + "";
        }

        private void cmdShow_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Book", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeBooksGV.DataSource = dt;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "" && txtAuthor.Text == "" && Authors.Count == 0 && txtGenre.Text == "" && Genres.Count == 0 && txtYearPublished.Text == "" && txtAvailableCopies.Text == "" && txtStatus.Text == "")
            {
                MessageBox.Show("Please fill out all text boxes....");
            }
            else
            {
                string Title = txtName.Text;
                int YearPublished = int.Parse(txtYearPublished.Text);
                int AvailableCopies = int.Parse(txtAvailableCopies.Text);
                int TotalCopies = int.Parse(txtCopies.Text);
                string Status = txtStatus.Text;
                Book b = new Book(id, Title, YearPublished, TotalCopies, AvailableCopies, Status, Authors, Genres);
                res = BookDL.EditBook(b);
                if (res == true)
                {
                    MessageBox.Show("Successfully Updated...");
                }
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                DataTable dt = new DataTable();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Book WHERE BookID LIKE '%" + id + "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                EmployeeBooksGV.DataSource = dt;
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

        private void txtAvailableCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtYearPublished_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
