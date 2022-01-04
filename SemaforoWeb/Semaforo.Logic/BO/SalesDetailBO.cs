using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Semaforo.Logic.BO
{
    public class SalesDetailBO
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int? SizeId { get; set; }
        public decimal Price { get; set; }
        public decimal? SpecialPrice { get; set; }
        public string Barcode { get; set; }
        public bool Delivered { get; set; }

    }
}
