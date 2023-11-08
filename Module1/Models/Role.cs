using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class Role
    {
        public Role()
        {
            DocGia = new HashSet<DocGium>();
            DoiTacs = new HashSet<DoiTac>();
            NhaBaos = new HashSet<NhaBao>();
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<DocGium> DocGia { get; set; }
        public virtual ICollection<DoiTac> DoiTacs { get; set; }
        public virtual ICollection<NhaBao> NhaBaos { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
