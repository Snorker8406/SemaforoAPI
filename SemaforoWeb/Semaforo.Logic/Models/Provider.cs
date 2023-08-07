using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Files = new HashSet<File>();
            ProviderAccounts = new HashSet<ProviderAccount>();
        }

        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ContactName { get; set; }
        public string Cellphone { get; set; }
        public string BankAccounts { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Whatsapp { get; set; }
        public string Website { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<ProviderAccount> ProviderAccounts { get; set; }
    }
}
