using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Floor
    {
        private int FloorID;
        private int Number;
        private List<Genre> Genres;

        public int FloorID1 { get => FloorID; set => FloorID = value; }
        public int Number1 { get => Number; set => Number = value; }
        public List<Genre> Genres1 { get => Genres; set => Genres = value; }

        public Floor()
        {

        }

        public Floor(int FloorID, int Number, List<Genre> Genres) // with ID
        {
            this.FloorID = FloorID;
            this.Number = Number;
            this.Genres = Genres;
        }

        public Floor(int Number, List<Genre> Genres) // without ID
        {
            this.Number = Number;
            this.Genres = Genres;
        }
    }
}
