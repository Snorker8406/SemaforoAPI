using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaforo.Logic.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            Employees = new HashSet<Employee>();
        }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
