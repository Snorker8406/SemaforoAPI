using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Sizes
    {
        public Sizes()
        {
            Prices = new HashSet<Prices>();
            SalesDetails = new HashSet<SalesDetails>();
            Stock = new HashSet<Stock>();
        }

        public int SizeId { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Prices> Prices { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
