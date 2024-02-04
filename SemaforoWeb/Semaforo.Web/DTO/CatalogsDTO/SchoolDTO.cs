using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Semaforo.Web.DTO.CatalogsDTO
{
    public class SchoolDTO
    {
        public int SchoolId { get; set; }
        public int SchoolLevelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Ciudad { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string PrincipalInfo { get; set; }
        public byte[] Logo { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

    }
}
