using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Web.DTO.CatalogsDTO
{
    public class CatalogDTO<T>
    {
        public CatalogDTO()
        {
            this.Columns = new List<CatalogFieldDTO>();
            this.Data = new List<T>();
        }
        public List<CatalogFieldDTO> Columns { get; set; }

        public List<T> Data { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

    }
}
