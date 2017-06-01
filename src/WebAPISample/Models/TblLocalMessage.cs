using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblLocalMessage
    {
        public long Id { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public DateTime SendDate { get; set; }
        public string Content { get; set; }
        public bool Received { get; set; }
    }
}
