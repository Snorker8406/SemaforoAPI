using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Sale
    {
        public Sale()
        {
            Accounts = new HashSet<Account>();
            SalesDetails = new HashSet<SalesDetail>();
        }

        public int SaleId { get; set; }
        public int EmployeeId { get; set; }
        public int? ClientId { get; set; }
        public int SiteId { get; set; }
        public int SaleTypeId { get; set; }
        public DateTime? SaleDate { get; set; }
        public string Notes { get; set; }
        public string ClientName { get; set; }
        public decimal? Total { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual SalesType SaleType { get; set; }
        public virtual Site Site { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
