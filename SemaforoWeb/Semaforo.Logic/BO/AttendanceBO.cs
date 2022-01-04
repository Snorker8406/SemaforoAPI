using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Logic.BO
{
    public class AttendanceBO
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public int Weekday { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? StopDate { get; set; }

    }
}
