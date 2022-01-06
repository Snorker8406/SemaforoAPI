using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class SalesType
    {
        public SalesType()
        {
            Sales = new HashSet<Sale>();
        }

        public int SaleTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
