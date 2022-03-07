using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO.Catalogs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModify { get; set; }
        public int LastModifiedBy { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public bool? Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public byte[] ProfileImage { get; set; }
        public byte[] Photo { get; set; }

    }
}
