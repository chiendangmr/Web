using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblRecordApp
    {
        public int RecordAppId { get; set; }
        public string RecordAppName { get; set; }
        public int? RecordAppType { get; set; }
    }
}
