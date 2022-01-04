using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int SiteId { get; set; }
        public int? SizeId { get; set; }
        public int? SaleDetailId { get; set; }
        public decimal? PriceSpecial { get; set; }
        public DateTime CreateDate { get; set; }
        public int? SerialNumber { get; set; }
        public int? Quantity { get; set; }
        public string Barcode { get; set; }

        public virtual Products Product { get; set; }
        public virtual SalesDetails SaleDetail { get; set; }
        public virtual Sites Site { get; set; }
        public virtual Sizes Size { get; set; }
    }
}
