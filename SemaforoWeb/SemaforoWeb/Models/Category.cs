using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? Enabled { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
