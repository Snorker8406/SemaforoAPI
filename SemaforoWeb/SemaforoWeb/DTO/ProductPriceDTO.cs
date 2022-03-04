using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO
{
    public class ProductPriceDTO
    {
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int? SizeId { get; set; }

    }
}
