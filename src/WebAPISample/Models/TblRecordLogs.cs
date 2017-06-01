using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblRecordLogs
    {
        public long RecordLogsId { get; set; }
        public DateTime? StartTime { get; set; }
        public int? OperateServerId { get; set; }
        public string ClipName { get; set; }
        public string RecordTcin { get; set; }
        public string RecordDuration { get; set; }
        public int? RecordStatus { get; set; }
    }
}
