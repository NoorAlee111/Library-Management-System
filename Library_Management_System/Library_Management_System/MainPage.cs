﻿using System;
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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(175, Color.Black);
            tableLayoutPanel2.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
        }

        private void cmdCreateAccount_Click(object sender, EventArgs e)
        {
            SignUp f = new SignUp();
            f.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
