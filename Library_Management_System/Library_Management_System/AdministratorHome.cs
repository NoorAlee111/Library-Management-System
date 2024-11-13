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
    public partial class AdministratorHome : Form
    {
        public AdministratorHome()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.FromArgb(255, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
            pictureBox1.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void AdministratorHome_Load(object sender, EventArgs e)
        {

        }

        private void cmdEmployees_Click(object sender, EventArgs e)
        {
            Employees f = new Employees();
            f.Show();
        }

        private void cmdAttendance_Click(object sender, EventArgs e)
        {
            Attendance f = new Attendance();
            f.Show();
        }

        private void cmdRanks_Click(object sender, EventArgs e)
        {
            Ranks f = new Ranks();
            f.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
