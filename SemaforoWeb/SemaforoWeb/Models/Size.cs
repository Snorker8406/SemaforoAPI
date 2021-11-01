using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class Size
    {
        public Size()
        {
            Prices = new HashSet<Price>();
            SalesDetails = new HashSet<SalesDetail>();
            Stocks = new HashSet<Stock>();
        }

        public int SizeId { get; set; }
        public string Size1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
