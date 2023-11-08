using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class User
    {
        public User()
        {
            BaiBaos = new HashSet<BaiBao>();
        }

        public int UserId { get; set; }
        public string? Ten { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public string? NgaySinh { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<BaiBao> BaiBaos { get; set; }
    }
}
