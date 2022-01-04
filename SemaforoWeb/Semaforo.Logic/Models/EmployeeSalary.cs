using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public int? Weekday { get; set; }
        public decimal? SalaryDay { get; set; }
        public decimal? SalaryHour { get; set; }

        public virtual Employees Employee { get; set; }
    }
}
