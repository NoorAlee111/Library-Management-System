using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Transaction
    {
        private int TransactionID;
        private string IssueDate;
        private string ReturnDate;
        private User User;
        private List<Book> Books;

        public int TransactionID1 { get => TransactionID; set => TransactionID = value; }
        public string IssueDate1 { get => IssueDate; set => IssueDate = value; }
        public string ReturnDate1 { get => ReturnDate; set => ReturnDate = value; }
        public User User1 { get => User; set => User = value; }
        public List<Book> Books1 { get => Books; set => Books = value; }

        public Transaction()
        {

        }

        public Transaction(int TransactionID, string IssueDate, string ReturnDate, User User, List<Book> Books) //with ID
        {
            this.TransactionID = TransactionID;
            this.IssueDate = IssueDate;
            this.ReturnDate = ReturnDate;
            this.User = User;
            this.Books = Books;
        }

        public Transaction(string IssueDate, string ReturnDate, User User, List<Book> Books) //wothout ID
        {
            this.IssueDate = IssueDate;
            this.ReturnDate = ReturnDate;
            this.User = User;
            this.Books = Books;
        }
    }
}
