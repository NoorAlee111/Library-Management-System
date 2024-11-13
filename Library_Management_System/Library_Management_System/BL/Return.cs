using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Return
    {
        private int ReturnID;
        private string ReturnDate;
        private float FineAmount;
        private User User;
        private List<Book> Books;

        public int ReturnID1 { get => ReturnID; set => ReturnID = value; }
        public string ReturnDate1 { get => ReturnDate; set => ReturnDate = value; }
        public float FineAmount1 { get => FineAmount; set => FineAmount = value; }
        public User User1 { get => User; set => User = value; }
        public List<Book> Books1 { get => Books; set => Books = value; }

        public Return()
        {

        }

        public Return(int ReturnID, string ReturnDate, float FineAmount, User User, List<Book> Books) // with ID
        {
            this.ReturnID = ReturnID;
            this.ReturnDate = ReturnDate;
            this.FineAmount = FineAmount;
            this.User = User;
            this.Books = Books;
        }

        public Return(string ReturnDate, float FineAmount, User User, List<Book> Books) // without ID
        {
            this.ReturnDate = ReturnDate;
            this.FineAmount = FineAmount;
            this.User = User;
            this.Books = Books;
        }

    }
}
