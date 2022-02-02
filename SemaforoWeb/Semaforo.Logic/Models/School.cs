using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class School
    {
        public School()
        {
            Embroideries = new HashSet<Embroidery>();
            ProductsSchools = new HashSet<ProductsSchool>();
        }

        public int SchoolId { get; set; }
        public int SchoolLevelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Ciudad { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string PrincipalInfo { get; set; }
        public byte[] Logo { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public virtual SchoolLevel SchoolLevel { get; set; }
        public virtual ICollection<Embroidery> Embroideries { get; set; }
        public virtual ICollection<ProductsSchool> ProductsSchools { get; set; }
    }
}
