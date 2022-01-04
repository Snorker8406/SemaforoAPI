using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Sites
    {
        public Sites()
        {
            Accounts = new HashSet<Accounts>();
            Sales = new HashSet<Sales>();
            Stock = new HashSet<Stock>();
        }

        public int SiteId { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
