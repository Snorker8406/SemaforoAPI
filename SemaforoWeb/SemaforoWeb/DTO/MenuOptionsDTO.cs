using System.Collections.Generic;

namespace SemaforoWeb.DTO
{
    public class MenuOptionsDTO
    {
        public string Category { get; set; }
        public string Label { get; set; }
        public List<string> subOptions { get; set; }
    }
}
