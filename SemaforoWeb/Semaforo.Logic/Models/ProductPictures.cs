using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProductPictures
    {
        public ProductPictures()
        {
            Products = new HashSet<Products>();
        }

        public int ProductPictureId { get; set; }
        public int ProductId { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Products Product { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
