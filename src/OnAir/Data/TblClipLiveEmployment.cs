using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblClipLiveEmployment
    {
        public long ClipLiveId { get; set; }
        public int EmployeeId { get; set; }
        public int JobTitleId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public long Id { get; set; }
    }
}
