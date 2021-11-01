using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class AccountPayment
    {
        public int AccountPaymentId { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }

        public virtual Account Account { get; set; }
    }
}
