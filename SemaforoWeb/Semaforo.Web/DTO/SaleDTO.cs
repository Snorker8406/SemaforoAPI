using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Web.DTO
{
    public class SaleDTO
    {
        public int SaleId { get; set; }
        public int UserId { get; set; }
        public int? ClientId { get; set; }
        public int SiteId { get; set; }
        public int SaleTypeId { get; set; }
        public DateTime SaleDate { get; set; }
        public string Notes { get; set; }
        public string ClientName { get; set; }
        public decimal? Total { get; set; }

    }
}
