using System;

namespace SemaforoWeb.DTO
{
    public class FileDTO
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
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Archive { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
