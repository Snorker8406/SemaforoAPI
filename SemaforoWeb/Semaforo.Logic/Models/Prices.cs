using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Prices
    {
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int? SizeId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Sizes Size { get; set; }
    }
}
