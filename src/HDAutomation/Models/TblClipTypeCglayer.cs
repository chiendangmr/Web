using System;
using System.Collections.Generic;

namespace HDAutomation.Models
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
