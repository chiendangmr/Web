using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblThiemLogPlayList
    {
        public long Id { get; set; }
        public int? SectorId { get; set; }
        public DateTime? DateList { get; set; }
        public int? ApproverId { get; set; }
        public DateTime TimeUpdate { get; set; }
        public string ClipNames { get; set; }
    }
}
