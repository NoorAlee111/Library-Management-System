using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Administrator : User
    {
        private string Position;

        public string Position1 { get => Position; set => Position = value; }

        public Administrator()
        {

        }

        public Administrator(int UserID, string Username, string Password, string Email, Role Role, string Name, double Phone, string Position) : base(UserID, Username, Password, Email, Role, Name, Phone) // with UserID
        {
            this.Position = Position;
        }

        public Administrator(string Username, string Password, string Email, Role Role, string Name, double Phone, string Position) : base(Username, Password, Email, Role, Name, Phone) // without UserID
        {
            this.Position = Position;
        }
    }
}

