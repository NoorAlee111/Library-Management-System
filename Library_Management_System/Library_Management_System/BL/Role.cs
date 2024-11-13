using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Role
    {
        private int RoleID;
        private string Name;
        private string Category;

        public int RoleID1 { get => RoleID; set => RoleID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Category1 { get => Category; set => Category = value; }
        

        public Role()
        {

        }

        public Role(int RoleID, string Name, string Category) // with ID
        {
            this.RoleID = RoleID;
            this.Name = Name;
            this.Category = Category;
        }

        public Role(string Name, string Category) // without ID
        {
            this.Name = Name;
            this.Category = Category;
        }
    }
}
