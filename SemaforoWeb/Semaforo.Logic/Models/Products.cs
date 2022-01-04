using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Products
    {
        public Products()
        {
            Prices = new HashSet<Prices>();
            ProductCategory = new HashSet<ProductCategory>();
            ProductPictures = new HashSet<ProductPictures>();
            SalesDetails = new HashSet<SalesDetails>();
            Stock = new HashSet<Stock>();
        }

        public int ProductId { get; set; }
        public int? BrandId { get; set; }
        public int? ProductPictureId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Comments { get; set; }
        public long? SerialCount { get; set; }
        public bool? Serialize { get; set; }

        public virtual Brands Brand { get; set; }
        public virtual ProductPictures ProductPicture { get; set; }
        public virtual ICollection<Prices> Prices { get; set; }
        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
        public virtual ICollection<ProductPictures> ProductPictures { get; set; }
        public virtual ICollection<SalesDetails> SalesDetails { get; set; }
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
