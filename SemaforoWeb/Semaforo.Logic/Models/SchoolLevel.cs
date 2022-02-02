using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class SchoolLevel
    {
        public SchoolLevel()
        {
            Schools = new HashSet<School>();
        }

        public int SchoolLevelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}
