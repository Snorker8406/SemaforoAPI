using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProductPicture
    {
        public ProductPicture()
        {
            Products = new HashSet<Product>();
        }

        public int ProductPictureId { get; set; }
        public int ProductId { get; set; }
        public byte[] Picture { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
