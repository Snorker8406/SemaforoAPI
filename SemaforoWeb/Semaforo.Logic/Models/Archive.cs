using System;
using System.Collections.Generic;

#nullable disable

namespace Semaforo.Logic.Models
{
    public partial class Archive
    {
        public Archive()
        {
            Files = new HashSet<File>();
        }

        public int ArchiveId { get; set; }
        public byte[] Data { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
