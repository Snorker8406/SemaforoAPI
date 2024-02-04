using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Web.DTO
{
    public class ProductPictureDTO
    {
        public int ProductPictureId { get; set; }
        public int ProductId { get; set; }
        public byte[] Picture { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
