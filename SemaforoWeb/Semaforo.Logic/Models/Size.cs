using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Size
    {
        public Size()
        {
            ProductPrices = new HashSet<ProductPrice>();
            SalesDetails = new HashSet<SalesDetail>();
            Stocks = new HashSet<Stock>();
        }

        public int SizeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
