using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Web.DTO.CatalogsDTO
{
    public class CatalogFieldDTO
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsColumn { get; set; }
        public bool IsInForm { get; set; }
        public bool Required { get; set; }
        public string ValidationPattern { get; set; }
        public int Size { get; set; }
        public int Rows { get; set; }
        public string SelectKey { get; set; }
        public string SelectOption { get; set; }
        public string SelectEntity { get; set; }
        public string DefaultValue { get; set; }
    }
}
