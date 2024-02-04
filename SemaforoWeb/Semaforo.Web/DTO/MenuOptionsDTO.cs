using System.Collections.Generic;

namespace Semaforo.Web.DTO
{
    public class MenuOptionsDTO
    {
        public string Category { get; set; }
        public string Label { get; set; }
        public List<string> subOptions { get; set; }
    }
}
