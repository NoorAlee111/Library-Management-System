using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Library_Management_System.BL
{
    public class Book
    {
        private int BookID;
        private string Title;
        private int YearPublished;
        private int TotalCopies;
        private int AvailableCopies;
        private float AvailablePercentage;
        private String Status;
        private List<Author> Author;
        private List<Genre> Genre;

        public int BookID1 { get => BookID; set => BookID = value; }
        public string Title1 { get => Title; set => Title = value; }
        public int YearPublished1 { get => YearPublished; set => YearPublished = value; }
        public int TotalCopies1 { get => TotalCopies; set => TotalCopies = value; }
        public int AvailableCopies1 { get => AvailableCopies; set => AvailableCopies = value; }
        public float AvailablePercentage1 { get => AvailablePercentage; set => AvailablePercentage = value; }
        public String Status1 { get => Status; set => Status = value; }
        public List<Author> Author1 { get => Author; set => Author = value; }
        public List<Genre> Genre1 { get => Genre; set => Genre = value; }

        public Book()
        {

        }

        public Book(int BookID, string Title, int YearPublished, int TotalCopies, int AvailableCopies, String Status, List<Author> Author, List<Genre> Genre) // with ID
        {
            this.BookID = BookID;
            this.Title = Title;
            this.TotalCopies = TotalCopies;
            this.AvailableCopies = AvailableCopies;
            this.AvailablePercentage = (AvailableCopies / TotalCopies) * 100;
            this.Status = Status;
            this.Author = Author;
            this.Genre = Genre;
        }

        public Book(string Title, int YearPublished, int TotalCopies, int AvailableCopies,  String Status, List<Author> Author, List<Genre> Genre) // withoutdone ID
        {
            this.Title = Title;
            this.TotalCopies = TotalCopies;
            this.AvailableCopies = AvailableCopies;
            this.AvailablePercentage = (AvailableCopies / TotalCopies) * 100;
            this.Status = Status;
            this.Author = Author;
            this.Genre = Genre;
        }
    
    }
}
