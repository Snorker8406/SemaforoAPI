using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class SalesTypes
    {
        public SalesTypes()
        {
            Sales = new HashSet<Sales>();
        }

        public int SaleTypeId { get; set; }
        public string SaleType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
