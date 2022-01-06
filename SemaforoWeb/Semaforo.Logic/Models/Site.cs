using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Site
    {
        public Site()
        {
            Accounts = new HashSet<Account>();
            Sales = new HashSet<Sale>();
            Stocks = new HashSet<Stock>();
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

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
