using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ProductSchool
    {
        public int ProductId { get; set; }
        public int SchoolId { get; set; }

        public virtual Product Product { get; set; }
        public virtual School School { get; set; }
    }
}
