using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class Price
    {
        public int PriceId { get; set; }
        public decimal Price1 { get; set; }
        public int ProductId { get; set; }
        public int? SizeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
