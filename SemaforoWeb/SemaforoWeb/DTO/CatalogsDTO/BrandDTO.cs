using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO.Catalogs
{
    public class BrandDTO
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SupplierId { get; set; }

    }
}
