﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace Library_Management_System
{
    public partial class Report8 : Form
    {
        public Report8()
        {
            InitializeComponent();
            tableLayoutPanel2.BackColor = Color.FromArgb(185, Color.Black);
        }

        private void Report8_Load(object sender, EventArgs e)
        {

        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            string query = "Select * From LibrarianDetails";
            SqlCommand command = new SqlCommand(query, con);
            DataTable data = new DataTable();
            SqlDataReader reader = command.ExecuteReader();
            data.Load(reader);

            ReportDocument r = new ReportDocument();
            string path = Application.StartupPath;
            string reportpath = @"C:\Users\hassan\Documents\GitHub\db2021finalprojectg-31\Library_Management_System\Library_Management_System\CrystalReport8.rpt";
            string fpath = Path.Combine(path, reportpath);
            r.Load(fpath);
            crystalReportViewer1.ReportSource = r;

            //r.ExportToDisk(ExportFormatType.PortableDocFormat, @"C:\Users\hassan\Documents\GitHub\db2021finalprojectg-31\Report8.pdf");
        }
    }
}
