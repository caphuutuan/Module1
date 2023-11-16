using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class BaiBao
    {
        public BaiBao()
        {
            Ctdhs = new HashSet<Ctdh>();
        }

        public int MaBb { get; set; }
        public int? MaTl { get; set; }
        public int? UserId { get; set; }
        public string TenBb { get; set; } = null!;
        public DateTime? NgayViet { get; set; }
        public string? NoiDung { get; set; }
        public DateTime? NgayChinhSua { get; set; }
        public double? DanhGia { get; set; }
        public int Status { get; set; }
        //public string StatusText => GetStatusText(Status);

        //private string GetStatusText(int status)
        //{
        //    switch (status)
        //    {
        //        case 0:
        //            return "Từ chối";
        //        case 1:
        //            return "Đã duyệt";
        //        // Thêm các trạng thái khác nếu cần
        //        default:
        //            return "Đang chờ duyệt";
        //    }
        //}
        public int? MaLv { get; set; }
        public string? Thumb { get; set; }
        public bool? Active { get; set; }

        public virtual LinhVucNb? MaLvNavigation { get; set; }
        public virtual TheLoaiBaiBao? MaTlNavigation { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Ctdh> Ctdhs { get; set; }
    }
}
