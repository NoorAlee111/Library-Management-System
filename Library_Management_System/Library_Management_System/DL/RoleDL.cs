using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System.BL;
using System.Data.SqlClient;

namespace Library_Management_System.DL
{
    public class RoleDL
    {
        private static List<Role> RoleList = new List<Role>();

        public static List<Role> RoleList1 { get => RoleList; set => RoleList = value; }

        public static void LoadRoles()
        {

        }

    }
}
