using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Logic.BO
{
    public class AccountPaymentBO
    {
        public int AccountPaymentId { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Notes { get; set; }

    }
}
