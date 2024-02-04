using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Web.DTO.CatalogsDTO.Catalogs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public int? BrandId { get; set; }
        public int? ProductPictureId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Comments { get; set; }
        public long? SerialCount { get; set; }
        public bool? Serialize { get; set; }

    }
}
