using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class User
    {
        private int UserID;
        private string Username;
        private string Password;
        private string Email;
        private Role Role;
        private string Name;
        private double Phone;

        public int UserID1 { get => UserID; set => UserID = value; }
        public string Username1 { get => Username; set => Username = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Email1 { get => Email; set => Email = value; }
        public Role Role1 { get => Role; set => Role = value; }
        public string Name1 { get => Name; set => Name = value; }
        public double Phone1 { get => Phone; set => Phone = value; }

        public User()
        {

        }

        public User(int UserID, string Username, string Password, string Email, Role Role, string Name, double Phone) // with UserID
        {
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.Role = Role;
            this.Name = Name;
            this.Phone = Phone;
        }

        public User(string Username, string Password, string Email, Role Role, string Name, double Phone) //without UserID
        {
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.Role = Role;
            this.Name = Name;
            this.Phone = Phone;
        }
    
    }
}
