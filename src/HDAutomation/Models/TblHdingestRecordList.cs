using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblHdingestRecordList
    {
        public long Id { get; set; }
        public long? IdClip { get; set; }
        public int? Vtrid { get; set; }
        public int? LiveInput { get; set; }
        public bool? IsRecordLive { get; set; }
        public int? RecordServerId { get; set; }
        public DateTime? RecordTime { get; set; }
        public int? RecordStatus { get; set; }
        public int? RecordAppId { get; set; }
    }
}
