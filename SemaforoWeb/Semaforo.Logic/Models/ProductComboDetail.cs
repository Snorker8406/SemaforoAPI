using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProductComboDetail
    {
        public int ProductComboDetailId { get; set; }
        public int ProductComboId { get; set; }
        public int? ProductId { get; set; }
        public int? EmbroideryId { get; set; }

        public virtual Embroidery Embroidery { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductCombo ProductCombo { get; set; }
    }
}
