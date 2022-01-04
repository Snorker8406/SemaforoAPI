using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class SalesDetails
    {
        public SalesDetails()
        {
            Stock = new HashSet<Stock>();
        }

        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int? SizeId { get; set; }
        public decimal Price { get; set; }
        public decimal? SpecialPrice { get; set; }
        public string Barcode { get; set; }
        public bool Delivered { get; set; }

        public virtual Products Product { get; set; }
        public virtual Sales Sale { get; set; }
        public virtual Sizes Size { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
