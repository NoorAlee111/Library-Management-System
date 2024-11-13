using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Issuance
    {
        private int IssaunceID;
        private string IssuanceDate;
        private string DueDate;
        private string ReturnDate;
        private int OverDueDate;
        private User User;
        private List<Book> Books;

        public int IssaunceID1 { get => IssaunceID; set => IssaunceID = value; }
        public string IssuanceDate1 { get => IssuanceDate; set => IssuanceDate = value; }
        public string DueDate1 { get => DueDate; set => DueDate = value; }
        public string ReturnDate1 { get => ReturnDate; set => ReturnDate = value; }
        public int OverDueDate1 { get => OverDueDate; set => OverDueDate = value; }
        public User User1 { get => User; set => User = value; }
        public List<Book> Books1 { get => Books; set => Books = value; }
        

        public Issuance()
        {

        }

        public Issuance(int IssuanceID, string IssuanceDate, string DueDate, string ReturnDate, int OverDueDate, User User, List<Book> Books) // with IssuanceID
        {
            this.IssaunceID = IssuanceID;
            this.IssuanceDate = IssuanceDate;
            this.DueDate = DueDate;
            this.ReturnDate = ReturnDate;
            this.OverDueDate = OverDueDate;
            this.User = User;
            this.Books = Books;
        }

        public Issuance(string IssuanceDate, string DueDate, string ReturnDate, int OverDueDate, User User, List<Book> Books) // without IssuanceID
        {
            this.IssuanceDate = IssuanceDate;
            this.DueDate = DueDate;
            this.ReturnDate = ReturnDate;
            this.OverDueDate = OverDueDate;
            this.User = User;
            this.Books = Books;
        }
    }
}
