using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class Status
    {
        private int StatusID;
        private string Name;          
        private string Category;
                                         
        public int StatusID1 { get => StatusID; set => StatusID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Category1 { get => Category; set => Category = value; }
                        
        public Status()
        {
                            
        }
        public Status(int StatusID, string Name, string Category) // with ID 
        {
            this.StatusID = StatusID;
            this.Name = Name;
            this.Category = Category;
        }
        public Status(string Name, string Category) // without ID 
        {
            this.Name = Name;
            this.Category = Category;
        }
    }
}
