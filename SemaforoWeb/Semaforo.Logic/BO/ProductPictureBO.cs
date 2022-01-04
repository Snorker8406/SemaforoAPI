using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Semaforo.Logic.BO
{
    public class ProductPictureBO
    {
        public int ProductPictureId { get; set; }
        public int ProductId { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
