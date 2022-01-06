using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class EmployeeSchedule
    {
        public int EmployeeScheduleId { get; set; }
        public int EmployeeId { get; set; }
        public int Weekday { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? StopTime { get; set; }
        public TimeSpan? BreakTime { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
