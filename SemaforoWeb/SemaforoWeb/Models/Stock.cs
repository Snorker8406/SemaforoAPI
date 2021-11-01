using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
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

        public virtual Product Product { get; set; }
        public virtual SalesDetail SaleDetail { get; set; }
        public virtual Site Site { get; set; }
        public virtual Size Size { get; set; }
    }
}
