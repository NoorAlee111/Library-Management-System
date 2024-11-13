using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class StudentsHome : Form
    {
        public StudentsHome()
        {
            InitializeComponent();
            tableLayoutPanel2.BackColor = Color.FromArgb(175, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void StudentsHome_Load(object sender, EventArgs e)
        {

        }

        private void cmdBooks_Click(object sender, EventArgs e)
        {
            AllBooks f = new AllBooks();
            f.Show();
        }

        private void cmdAuthor_Click(object sender, EventArgs e)
        {
            Authors f = new Authors();
            f.Show();
        }

        private void cmdIssueBooks_Click(object sender, EventArgs e)
        {
            IssueBooks f = new IssueBooks();
            f.Show();
        }

        private void cmdTransaction_Click(object sender, EventArgs e)
        {
            TransactionHistory f = new TransactionHistory();
            f.Show();
        }

        private void cmdFloors_Click(object sender, EventArgs e)
        {
            Floors f = new Floors();
            f.Show();
        }

        private void cmdPdf_Click(object sender, EventArgs e)
        {
            FinesReport f = new FinesReport();
            f.Show();
        }

        private void cmdGenre_Click(object sender, EventArgs e)
        {
            Genres f = new Genres();
            f.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
