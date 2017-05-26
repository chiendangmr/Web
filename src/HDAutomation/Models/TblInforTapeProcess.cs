using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblInforTapeProcess
    {
        public long IdClip { get; set; }
        public int ProcessId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? StatusId { get; set; }
        public long Id { get; set; }
    }
}
