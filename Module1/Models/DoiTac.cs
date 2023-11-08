﻿using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class DoiTac
    {
        public int MaDt { get; set; }
        public string? Ten { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string? Status { get; set; }

        public virtual Role? Role { get; set; }
    }
}
