using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgVideo
    {
        public long Id { get; set; }
        public long? ClipId { get; set; }
        public string PlayTcIn { get; set; }
        public string PlayTcOut { get; set; }
    }
}
