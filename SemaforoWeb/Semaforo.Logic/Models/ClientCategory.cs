using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class ClientCategory
    {
        public ClientCategory()
        {
            Clients = new HashSet<Client>();
        }

        public int ClientCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
