using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO
{
    public class PriceDTO
    {
        public int PriceId { get; set; }
        public decimal Price1 { get; set; }
        public int ProductId { get; set; }
        public int? SizeId { get; set; }

    }
}
