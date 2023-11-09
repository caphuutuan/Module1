using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class LinhVucNb
    {
        public LinhVucNb()
        {
            BaiBaos = new HashSet<BaiBao>();
        }

        public int MaLinhVuc { get; set; }
        public string? TenLinhVuc { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<BaiBao> BaiBaos { get; set; }
    }
}
