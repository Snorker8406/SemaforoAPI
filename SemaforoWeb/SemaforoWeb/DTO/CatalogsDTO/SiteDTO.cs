using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO.Catalogs
{
    public class SiteDTO
    {
        public int SiteId { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

    }
}
