using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class Product
    {
        public Product()
        {
            Prices = new HashSet<Price>();
            ProductCategories = new HashSet<ProductCategory>();
            ProductPictures = new HashSet<ProductPicture>();
            SalesDetails = new HashSet<SalesDetail>();
            Stocks = new HashSet<Stock>();
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

        public virtual Brand Brand { get; set; }
        public virtual ProductPicture ProductPicture { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
