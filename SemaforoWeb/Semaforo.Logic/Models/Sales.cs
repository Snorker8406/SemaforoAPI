using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Sales
    {
        public Sales()
        {
            Accounts = new HashSet<Accounts>();
            SalesDetails = new HashSet<SalesDetails>();
        }

        public int SaleId { get; set; }
        public int UserId { get; set; }
        public int? ClientId { get; set; }
        public int SiteId { get; set; }
        public int SaleTypeId { get; set; }
        public DateTime SaleDate { get; set; }
        public string Notes { get; set; }
        public string ClientName { get; set; }
        public decimal? Total { get; set; }

        public virtual Clients Client { get; set; }
        public virtual SalesTypes SaleType { get; set; }
        public virtual Sites Site { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
    }
}
