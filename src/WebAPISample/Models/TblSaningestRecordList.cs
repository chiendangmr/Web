using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblSaningestRecordList
    {
        public long Id { get; set; }
        public long? IdClip { get; set; }
        public int? Vtrid { get; set; }
        public int? LiveInput { get; set; }
        public bool? IsRecordLive { get; set; }
        public DateTime? RecordTime { get; set; }
        public bool? IsAutoMode { get; set; }
        public int? RecordStatus { get; set; }
        public int? RecordAppId { get; set; }
    }
}
