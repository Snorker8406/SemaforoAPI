using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AccountPayments = new HashSet<AccountPayment>();
            Accounts = new HashSet<Account>();
            Attendances = new HashSet<Attendance>();
            Clients = new HashSet<Client>();
            EmployeeSalaries = new HashSet<EmployeeSalary>();
            EmployeeSchedules = new HashSet<EmployeeSchedule>();
            Files = new HashSet<File>();
            ProviderAccountPayments = new HashSet<ProviderAccountPayment>();
            ProviderAccounts = new HashSet<ProviderAccount>();
            Sales = new HashSet<Sale>();
        }

        public int EmployeeId { get; set; }
        public string AppUserId { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime? CreateDate { get; set; }
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
        public bool? Active { get; set; }
        public string Comments { get; set; }

        public virtual ApplicationUser AppUser { get; set; }
        public virtual ICollection<AccountPayment> AccountPayments { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<ProviderAccountPayment> ProviderAccountPayments { get; set; }
        public virtual ICollection<ProviderAccount> ProviderAccounts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
