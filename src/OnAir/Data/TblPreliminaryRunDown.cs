using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblPreliminaryRunDown
    {
        public long RunDownId { get; set; }
        public long NewsId { get; set; }
        public int OrderNo { get; set; }
        public string Mcduration { get; set; }
        public string ClipDuration { get; set; }
        public int? ItemType { get; set; }
        public long Id { get; set; }
    }
}
