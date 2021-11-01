using System;
using System.Collections.Generic;

#nullable disable

namespace SemaforoWeb.Models
{
    public partial class Role
    {
        public int RoleId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModify { get; set; }
        public int LastModifiedBy { get; set; }
        public string Status { get; set; }
        public bool Deleted { get; set; }
        public string Role1 { get; set; }
        public string Description { get; set; }
    }
}
