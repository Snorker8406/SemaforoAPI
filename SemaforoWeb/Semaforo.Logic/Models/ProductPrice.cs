using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProductPrice
    {
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public int? SizeId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
