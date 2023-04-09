using Semaforo.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Semaforo.Logic.BO
{
    public class ClientBO
    {
        public ClientBO()
        {
            Employees_Options = new Dictionary<int, string>();
            ClientStatuses_Options = new Dictionary<int, string>();
            CreateDate = DateTime.UtcNow;
            LastModify = DateTime.UtcNow;
        }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientStatusId { get; set; }
        public int ClientCategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModify { get; set; }
        public int LastModifiedBy { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastNameMother { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int? AccountDaysLimit { get; set; }
        public decimal? AccountAmountLimit { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public bool Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }
        public List<FileBO> Files { get; set; }
        public string Comments { get; set; }
        public string EmployeeName { get; set; }
        public Dictionary<int, string> Employees_Options { get; set; }
        public Dictionary<int, string> ClientStatuses_Options { get; set; }
        public Dictionary<int, string> ClientCategories_Options { get; set; }
    }
}
