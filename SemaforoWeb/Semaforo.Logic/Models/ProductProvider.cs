using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProductProvider
    {
        public int ProductId { get; set; }
        public int ProviderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
