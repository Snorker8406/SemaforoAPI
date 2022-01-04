using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public int Weekday { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StopDate { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
