using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class Ctdh
    {
        public int MaCtdh { get; set; }
        public int? MaDh { get; set; }
        public int? MaBb { get; set; }
        public int? Gia { get; set; }
        public int? ThanhTien { get; set; }

        public virtual DonHang? MaDh1 { get; set; }
        public virtual BaiBao? MaDhNavigation { get; set; }
    }
}
