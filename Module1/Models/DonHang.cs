using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            Ctdhs = new HashSet<Ctdh>();
        }

        public int MaDh { get; set; }
        public int? UserId { get; set; }
        public DateTime? NgayDat { get; set; }
        public int? TongTien { get; set; }

        public virtual ICollection<Ctdh> Ctdhs { get; set; }
    }
}
