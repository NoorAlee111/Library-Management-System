using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Genre
    {
        private int GenreID;
        private string Name;

        public int GenreID1 { get => GenreID; set => GenreID = value; }
        public string Name1 { get => Name; set => Name = value; }

        public Genre()
        {

        }

        public Genre(int GenreID, string Name) // with ID
        {
            this.GenreID = GenreID;
            this.Name = Name;
        }

        public Genre(string Name) // without ID
        {
            this.Name = Name;
        }
    }
}
