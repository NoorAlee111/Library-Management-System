using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.BL;
using System.Data.SqlClient;

namespace Library_Management_System.DL
{
    public class StatusDL
    {
        private static List<Status> StatusList = new List<Status>();

        public static List<Status> StatusList1 { get => StatusList; set => StatusList = value; }

        public static void LoadStatuses()
        {

        }
    }
}
