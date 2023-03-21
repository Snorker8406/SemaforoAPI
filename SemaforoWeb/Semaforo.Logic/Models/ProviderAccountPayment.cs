using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProviderAccountPayment
    {
        public ProviderAccountPayment()
        {
            Files = new HashSet<File>();
        }

        public int ProviderAccountPaymentId { get; set; }
        public int ProviderAccountId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ProviderAccount ProviderAccount { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
