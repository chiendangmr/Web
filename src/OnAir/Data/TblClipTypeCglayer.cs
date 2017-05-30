using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblClipTypeCglayer
    {
        public long Id { get; set; }
        public int TypeId { get; set; }
        public int CglayerId { get; set; }

        public virtual TblCglayer Cglayer { get; set; }
        public virtual TblClipTypes Type { get; set; }
    }
}
