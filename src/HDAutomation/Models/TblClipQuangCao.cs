using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblClipQuangCao
    {
        public long CutId { get; set; }
        public long IdClip { get; set; }
        public int ClipOrder { get; set; }
        public long? IdClipTvad { get; set; }
    }
}
