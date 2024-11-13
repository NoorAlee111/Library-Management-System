using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Student : User
    {
        private string RollNo;

        public string RollNo1 { get => RollNo; set => RollNo = value; }

        public Student()
        {

        }

        public Student(int UserID, string Username, string Password, string Email, Role Role, string Name, double Phone, string RollNo) : base(UserID, Username, Password, Email, Role, Name, Phone) // with UserID
        {
            this.RollNo = RollNo;
        }

        public Student(string Username, string Password, string Email, Role Role, string Name, double Phone, string RollNo) : base(Username, Password, Email, Role, Name, Phone) // without UserID
        {
            this.RollNo = RollNo;
        }
    }
}
