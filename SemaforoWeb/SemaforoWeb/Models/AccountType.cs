using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public string AccountType1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
