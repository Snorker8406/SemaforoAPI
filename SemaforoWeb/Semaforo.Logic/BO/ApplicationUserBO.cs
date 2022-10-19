using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Semaforo.Logic.BO
{
    public class ApplicationUserBO
    {
        public ApplicationUserBO()
        {
            CreateDate = DateTime.Now;
        }
        public int EmployeeId { get; set; }
        public string AppUserId { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string Phone { get; set; }
        public string HealthInfo { get; set; }
        public string MaritalStatus { get; set; }
        public bool Active { get; set; }
        public string Comments { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModify { get; set; }
        public int LastModifiedBy { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }
        public byte[] Photo { get; set; }

    }
}
