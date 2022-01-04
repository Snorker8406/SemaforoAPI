using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class AccountTypes
    {
        public AccountTypes()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
