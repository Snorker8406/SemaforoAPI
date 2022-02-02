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
            EmployeeRoles = new HashSet<EmployeeRole>();
            EmployeeSalaries = new HashSet<EmployeeSalary>();
            EmployeeSchedules = new HashSet<EmployeeSchedule>();
        }

        public int EmployeeId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte[] Photo { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public bool? WhatsApp { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public byte[] FacebookProfileImage { get; set; }
        public string HealthInfo { get; set; }
        public string MaritalStatus { get; set; }
        public bool Active { get; set; }
        public string Comments { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
