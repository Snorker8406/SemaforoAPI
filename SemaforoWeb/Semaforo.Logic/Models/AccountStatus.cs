using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class AccountStatus
    {
        public AccountStatus()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
