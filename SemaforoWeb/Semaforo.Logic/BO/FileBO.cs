using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaforo.Logic.BO
{
    public class FileBO
    {
        public int FileId { get; set; }
        public int? ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProviderId { get; set; }
        public int? SchoolId { get; set; }
        public int? AccountId { get; set; }
        public int? ProviderAccountId { get; set; }
        public int? ProviderAccountPaymentId { get; set; }
        public string Comments { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FieldType { get; set; }
        public string Size { get; set; }
        public byte[] Archive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
