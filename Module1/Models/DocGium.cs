using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class DocGium
    {
        public int MaDg { get; set; }
        public string? Email { get; set; }
        public string? TenDg { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? RoleId { get; set; }
        public string? Status { get; set; }

        public virtual Role? Role { get; set; }
    }
}
