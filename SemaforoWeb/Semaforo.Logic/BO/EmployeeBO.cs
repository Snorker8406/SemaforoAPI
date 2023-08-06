using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Semaforo.Logic.BO
{
    public class EmployeeBO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string FullName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte[] Photo { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public string HealthInfo { get; set; }
        public string MaritalStatus { get; set; }
        public bool Active { get; set; }
        public string Comments { get; set; }
        public List<FileBO> Files { get; set; }

    }
}
