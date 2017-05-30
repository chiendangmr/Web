using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblMasterClips
    {
        public int MasterClipId { get; set; }
        public string MasterClipName { get; set; }
        public string MasterClipComment { get; set; }
        public string MasterClipDuration { get; set; }
        public int? MasterClipTypeId { get; set; }
        public int? Status { get; set; }
        public DateTime? TermStart { get; set; }
        public DateTime? TermEnd { get; set; }
        public int TermRepeatType { get; set; }
        public int TermRepeat { get; set; }
    }
}
