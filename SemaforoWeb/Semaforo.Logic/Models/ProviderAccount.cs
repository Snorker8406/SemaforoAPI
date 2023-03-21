using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProviderAccount
    {
        public ProviderAccount()
        {
            Files = new HashSet<File>();
            ProviderAccountPayments = new HashSet<ProviderAccountPayment>();
        }

        public int ProviderAccountId { get; set; }
        public int EmployeeId { get; set; }
        public int? ProviderId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime? SettlementDate { get; set; }
        public decimal Balance { get; set; }
        public string Notes { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<ProviderAccountPayment> ProviderAccountPayments { get; set; }
    }
}
