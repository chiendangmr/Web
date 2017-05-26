using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblTranscodeEvent
    {
        public long Id { get; set; }
        public string OriginFileName { get; set; }
        public string NewFileName { get; set; }
        public int TranscoderId { get; set; }
        public int Status { get; set; }
        public DateTime? StartTime { get; set; }
        public long IdClip { get; set; }
    }
}
