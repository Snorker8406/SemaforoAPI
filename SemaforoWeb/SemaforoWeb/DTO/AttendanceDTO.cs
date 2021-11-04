using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO
{
    public class AttendanceDTO
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public int Weekday { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StopDate { get; set; }

    }
}
