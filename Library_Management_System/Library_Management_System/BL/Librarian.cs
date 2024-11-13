using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Librarian : User
    {
        private int LibrarianId;
        private string City;
        private string Country;
        private string Address;
        private String Status;
        private int FloorId;
      

        public string City1 { get => City; set => City = value; }
        public string Country1 { get => Country; set => Country = value; }
        public string Address1 { get => Address; set => Address = value; }
        public String Status1 { get => Status; set => Status = value; }
      
        public int FloorId1 { get => FloorId; set => FloorId = value; }
        public int LibrarianId1 { get => LibrarianId; set => LibrarianId = value; }

        public Librarian()
        {

        }

        public Librarian(int LibrarianId,int UserID, string Username, string Password, string Email, Role Role, string Name, double Phone, string City, string Country, string Address, String Status, int FloorId) : base(UserID, Username, Password, Email, Role, Name, Phone) // with UserID
        {
            this.LibrarianId = LibrarianId;
            this.City = City;
            this.Country = Country;
            this.Address = Address;
            this.Status = Status;

        }

        public Librarian(string Username, string Password, string Email, Role Role, string Name, double Phone, string City, string Country, string Address, String Status,int FloorId) : base(Username, Password, Email, Role, Name, Phone) // without UserID
        {
            this.City = City;
            this.Country = Country;
            this.Address = Address;
            this.Status = Status;
          
        }
    }
}
