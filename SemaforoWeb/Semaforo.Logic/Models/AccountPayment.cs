using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class AccountPayment
    {
        public int AccountPaymentId { get; set; }
        public int AccountId { get; set; }
        public int EmployeeId { get; set; }
        public int SiteId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }

        public virtual Account Account { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
