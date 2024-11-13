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
    public partial class EmployeeFloors : Form
    {
        public static List<Genre> Genres;
        private int id;

        public EmployeeFloors()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            tableLayoutPanel3.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel4.BackColor = Color.FromArgb(0, Color.Black);
            tableLayoutPanel5.BackColor = Color.FromArgb(0, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void EmployeeFloors_Load(object sender, EventArgs e)
        {
            FloorDL.LoadDataIntoGenreComboBox(txtGenre);
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

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            if(txtFloor.Text=="" && txtGenre.Text=="" )
            {
                MessageBox.Show("Fill out Text boxes...");
            }
            else
            {
                if (txtGenre.Text == "" && Genres.Count != 0)
                {
                   int FloorNo = int.Parse(txtFloor.Text);

                    Floor f = new Floor(FloorNo, Genres);
                    bool res = FloorDL.AddFloor(f);
                    if (res == true)
                    {
                        MessageBox.Show("Successfully saved...");
                    }
                }
                else if (txtGenre.Text != "")
                {
                    Genre g = getGenreObject(txtGenre.Text);
                    Genres.Add(g);

                    int FloorNo = int.Parse(txtFloor.Text);

                    Floor f = new Floor(FloorNo, Genres);
                    bool res = FloorDL.AddFloor(f);
                    if (res == true)
                    {
                        MessageBox.Show("Successfully saved...");
                    }
                }
            }
        }
        private void reloadUpdatedDatabase()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select f.FloorId,f.FloorNo,g.GenreName from Floors f join FloorsGenre fg on f.FloorId=fg.FloorId join Genre g on g.Id=fg.GenreId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeFloorsGV.DataSource = dt;
        }
        private void cmdShow_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select f.FloorId,f.FloorNo,g.GenreName from Floors f join FloorsGenre fg on f.FloorId=fg.FloorId join Genre g on g.Id=fg.GenreId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            EmployeeFloorsGV.DataSource = dt;
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

            if (txtFloor.Text == "" && txtGenre.Text == "")
            {
                MessageBox.Show("Fill out Text boxes...");
            }
            else
            {
                int FloorNo = int.Parse(txtFloor.Text);
                Floor f = new Floor(id,FloorNo,Genres);
                bool res = FloorDL.EditFloor(f);
                if (res == true)
                {
                    MessageBox.Show("Successfully Edited...");
                }
            }
            }

        private void EmployeeFloorsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow r = EmployeeFloorsGV.Rows[index];
            id = int.Parse(r.Cells[0].Value.ToString());
            txtFloor.Text = r.Cells[1].Value.ToString();

        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                DataTable dt = new DataTable();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Floors WHERE FloorId LIKE '%" + id + "%'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                EmployeeFloorsGV.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Select the Record you want to Search from table");
            }
        }

        private void txtFloor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
