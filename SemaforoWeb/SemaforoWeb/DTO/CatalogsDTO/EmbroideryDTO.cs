using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO.Catalogs
{
    public class EmbroideryDTO
    {
        public int EmbroideryId { get; set; }
        public int? SchoolId { get; set; }
        public string Name { get; set; }
        public byte[] EmbFile { get; set; }
        public byte[] DstFile { get; set; }
        public string Description { get; set; }
        public string Stiches { get; set; }
        public string ColorSecuence { get; set; }
        public decimal? Price { get; set; }
        public string ImageDesign { get; set; }
        public byte[] Image { get; set; }

        public virtual School School { get; set; }

    }
}
