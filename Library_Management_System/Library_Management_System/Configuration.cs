﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library_Management_System
{
    class Configuration
    {
        String ConnectionStr = @"Data Source=(local);Initial Catalog=LibraryManagementSystemm;Integrated Security=True";
        SqlConnection con;
        private static Configuration _instance;
        public static Configuration getInstance()
        {
            if (_instance == null)
                _instance = new Configuration();
            return _instance;
        }
        private Configuration()
        {
            con = new SqlConnection(ConnectionStr);
            con.Open();
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
}
