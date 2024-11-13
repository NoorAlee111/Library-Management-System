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
    public partial class EmployeesHome : Form
    {
        public EmployeesHome()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void EmployeesHome_Load(object sender, EventArgs e)
        {

        }

        private void cmdStudents_Click(object sender, EventArgs e)
        {
            Students f = new Students();
            f.Show();
        }

        private void cmdBooks_Click(object sender, EventArgs e)
        {
            EmployeeBooks f = new EmployeeBooks();
            f.Show();
        }

        private void cmdAuthors_Click(object sender, EventArgs e)
        {
            EmployeeAuthors f = new EmployeeAuthors();
            f.Show();
        }

        private void cmdIssuances_Click(object sender, EventArgs e)
        {
            EmployeeIssuances f = new EmployeeIssuances();
            f.Show();
        }

        private void cmdReturns_Click(object sender, EventArgs e)
        {
            EmployeeReturns f = new EmployeeReturns();
            f.Show();
        }

        private void cmdTransactions_Click(object sender, EventArgs e)
        {
            EmployeeTransactions f = new EmployeeTransactions();
            f.Show();
        }

        private void cmdFloors_Click(object sender, EventArgs e)
        {
            EmployeeFloors f = new EmployeeFloors();
            f.Show();
        }

        private void cmdGenre_Click(object sender, EventArgs e)
        {
            EmployeeGenre f = new EmployeeGenre();
            f.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
