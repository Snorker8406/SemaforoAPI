using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProductCombo
    {
        public ProductCombo()
        {
            ProductComboDetails = new HashSet<ProductComboDetail>();
        }

        public int ProductComboId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductComboDetail> ProductComboDetails { get; set; }
    }
}
