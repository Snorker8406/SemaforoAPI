using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class Client
    {
        public Client()
        {
            Accounts = new HashSet<Account>();
            Sales = new HashSet<Sale>();
        }

        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int ClientStatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModify { get; set; }
        public int LastModifiedBy { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastNameMother { get; set; }
        public int? AccountDaysLimit { get; set; }
        public decimal? AccountAmountLimit { get; set; }
        public bool? Student { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public bool Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string FacebookName { get; set; }
        public string Email { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Comments { get; set; }

        public virtual ClientStatus ClientStatus { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
