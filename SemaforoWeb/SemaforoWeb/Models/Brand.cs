using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SupplierId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
