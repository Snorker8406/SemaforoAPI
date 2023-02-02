using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.DTO.CatalogsDTO
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientStatusId { get; set; }
        public int? ClientCategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModify { get; set; }
        public int LastModifiedBy { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastNameMother { get; set; }
        public string Gender { get; set; }
        public int? AccountDaysLimit { get; set; }
        public decimal? AccountAmountLimit { get; set; }
        public bool? Student { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public bool Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Comments { get; set; }
    }
}
