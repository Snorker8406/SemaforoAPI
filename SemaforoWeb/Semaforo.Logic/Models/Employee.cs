using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Attendances = new HashSet<Attendance>();
            EmployeeSalaries = new HashSet<EmployeeSalary>();
            EmployeeSchedules = new HashSet<EmployeeSchedule>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public string HealthInfo { get; set; }
        public string MaritalStatus { get; set; }
        public bool Active { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
    }
}
