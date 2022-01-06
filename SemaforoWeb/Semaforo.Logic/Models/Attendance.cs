using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public int Weekday { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StopDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
