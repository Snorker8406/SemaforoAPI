using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO
{
    public class CatalogFieldDTO
    {
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsColumn { get; set; }
        public bool IsInForm { get; set; }
        public bool required { get; set; }
        public string validationPattern { get; set; }
        public int size { get; set; }
        public string dropdownKey { get; set; }
        public string dropdownOption { get; set; }
        public string dropdownEntity { get; set; }
    }
}
