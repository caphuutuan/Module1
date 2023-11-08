using System;
using System.Collections.Generic;

namespace Module1.Models
{
    public partial class TheLoaiBaiBao
    {
        public TheLoaiBaiBao()
        {
            BaiBaos = new HashSet<BaiBao>();
        }

        public int MaTl { get; set; }
        public string? TenTl { get; set; }

        public virtual ICollection<BaiBao> BaiBaos { get; set; }
    }
}
