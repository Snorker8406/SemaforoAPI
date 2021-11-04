using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO
{
    public class AccountDTO
    {
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
    }
}
