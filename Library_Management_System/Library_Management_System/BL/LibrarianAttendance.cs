using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.BL
{
    public class LibrarianAttendance
    {
        private int AttendanceID;
        private string Date;
        private Status Status;
        private int TotalPresentDays;

        public int AttendanceID1 { get => AttendanceID; set => AttendanceID = value; }
        public string Date1 { get => Date; set => Date = value; }
        public Status Status1 { get => Status; set => Status = value; }
        public int TotalPresentDays1 { get => TotalPresentDays; set => TotalPresentDays = value; }

        public LibrarianAttendance()
        {

        }

        public LibrarianAttendance(int AttendanceID, string Date, Status Status,int TotalPresentDays) //with ID
        {
            this.AttendanceID = AttendanceID;
            this.Date = Date;
            this.Status = Status;
            this.TotalPresentDays = TotalPresentDays;
        }

        public LibrarianAttendance(string Date, Status Status, int TotalPresentDays) // without ID
        {
            this.Date = Date;
            this.Status = Status;
            this.TotalPresentDays = TotalPresentDays;
        }
    }
}
