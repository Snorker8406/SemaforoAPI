using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class User: IdentityUser
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            Employees = new HashSet<Employee>();
            Sales = new HashSet<Sale>();
        }

        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModify { get; set; }
        public int LastModifiedBy { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
