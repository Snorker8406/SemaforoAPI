using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class AccountPayments
    {
        public int AccountPaymentId { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }

        public virtual Accounts Account { get; set; }
    }
}
