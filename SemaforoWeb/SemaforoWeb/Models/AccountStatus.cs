using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class AccountStatus
    {
        public AccountStatus()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountStatusId { get; set; }
        public string AccountStatus1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
