using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class EmployeeSalary
    {
        public int EmployeeSalaryId { get; set; }
        public int EmployeeId { get; set; }
        public int? Weekday { get; set; }
        public decimal? SalaryDay { get; set; }
        public decimal? SalaryHour { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
