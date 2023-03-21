using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountPayments = new HashSet<AccountPayment>();
            Files = new HashSet<File>();
        }

        public int AccountId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
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
        public virtual AccountType AccountType { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Site Site { get; set; }
        public virtual ICollection<AccountPayment> AccountPayments { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
