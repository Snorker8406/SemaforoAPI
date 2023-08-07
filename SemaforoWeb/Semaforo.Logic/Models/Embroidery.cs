using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Embroidery
    {
        public Embroidery()
        {
            ProductComboDetails = new HashSet<ProductComboDetail>();
        }

        public int EmbroideryId { get; set; }
        public int? SchoolId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public byte[] EmbFile { get; set; }
        public byte[] DstFile { get; set; }
        public string Description { get; set; }
        public string Stiches { get; set; }
        public string ColorSecuence { get; set; }
        public decimal? Price { get; set; }
        public string ImageDesign { get; set; }
        public byte[] Image { get; set; }

        public virtual School School { get; set; }
        public virtual ICollection<ProductComboDetail> ProductComboDetails { get; set; }
    }
}
