using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblAttachments
    {
        public long AttachedId { get; set; }
        public long NewsId { get; set; }
        public string FileName { get; set; }
        public int? UserUploadId { get; set; }
        public DateTime? UploadTime { get; set; }
    }
}
