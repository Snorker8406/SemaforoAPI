using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Semaforo.Web.DTO
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModify { get; set; }
        public int LastModifiedBy { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
