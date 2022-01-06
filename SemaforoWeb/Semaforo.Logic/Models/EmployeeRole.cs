using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class EmployeeRole
    {
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}
