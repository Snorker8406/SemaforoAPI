using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Attendance = new HashSet<Attendance>();
            EmployeeSalary = new HashSet<EmployeeSalary>();
            EmployeeSchedule = new HashSet<EmployeeSchedule>();
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

        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalary { get; set; }
        public virtual ICollection<EmployeeSchedule> EmployeeSchedule { get; set; }
    }
}
