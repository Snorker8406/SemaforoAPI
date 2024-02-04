using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Web.DTO.CatalogsDTO.Catalogs
{
    public class StockDTO
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int SiteId { get; set; }
        public int? SizeId { get; set; }
        public int? SaleDetailId { get; set; }
        public decimal? PriceSpecial { get; set; }
        public DateTime CreateDate { get; set; }
        public int? SerialNumber { get; set; }
        public int? Quantity { get; set; }
        public string Barcode { get; set; }

    }
}
