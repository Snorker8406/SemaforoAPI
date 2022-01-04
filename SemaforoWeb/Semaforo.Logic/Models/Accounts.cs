using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            AccountPayments = new HashSet<AccountPayments>();
        }

        public int AccountId { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public int AccountTypeId { get; set; }
        public int SaleId { get; set; }
        public int AccountStatusId { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? SettlementDate { get; set; }
        public DateTime? CancellationDate { get; set; }
        public string Notes { get; set; }
        public string Barcode { get; set; }
        public decimal Balance { get; set; }

        public virtual AccountStatus AccountStatus { get; set; }
        public virtual AccountTypes AccountType { get; set; }
        public virtual Clients Client { get; set; }
        public virtual Sales Sale { get; set; }
        public virtual Sites Site { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<AccountPayments> AccountPayments { get; set; }
    }
}
