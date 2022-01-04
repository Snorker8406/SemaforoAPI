using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class AccountStatus
    {
        public AccountStatus()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int AccountStatusId { get; set; }
        public string AccountStatus1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
