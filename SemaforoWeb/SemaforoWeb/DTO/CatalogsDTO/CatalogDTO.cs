using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO
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
    }
}
