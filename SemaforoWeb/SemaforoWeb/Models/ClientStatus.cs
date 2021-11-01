using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class ClientStatus
    {
        public ClientStatus()
        {
            Clients = new HashSet<Client>();
        }

        public int ClientStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
