using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class SalesDetail
    {
        public SalesDetail()
        {
            Stocks = new HashSet<Stock>();
        }

        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int? SizeId { get; set; }
        public decimal Price { get; set; }
        public decimal? SpecialPrice { get; set; }
        public string Barcode { get; set; }
        public bool Delivered { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
