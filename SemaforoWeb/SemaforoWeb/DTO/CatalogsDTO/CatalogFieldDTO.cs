using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO
{
    public class CatalogFieldDTO
    {
        public bool IsColumn { get; set; }
        public bool IsInForm { get; set; }
        public bool IsPrimaryKey { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string ColumnName { get; set; } // quitar
        public string Label { get; set; }
    }
}
