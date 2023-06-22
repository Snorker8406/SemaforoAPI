using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class File
    {
        public int FileId { get; set; }
        public int? ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProviderId { get; set; }
        public int? SchoolId { get; set; }
        public int? AccountId { get; set; }
        public int? ProviderAccountId { get; set; }
        public int? ProviderAccountPaymentId { get; set; }
        public int? ArchiveId { get; set; }
        public string Comments { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FieldType { get; set; }
        public string Size { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Account Account { get; set; }
        public virtual Archive Archive { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ProviderAccount ProviderAccount { get; set; }
        public virtual ProviderAccountPayment ProviderAccountPayment { get; set; }
        public virtual School School { get; set; }
    }
}
