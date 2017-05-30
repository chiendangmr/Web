using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblMasterClipRerun
    {
        public int Id { get; set; }
        public int MasterClipRepeatId { get; set; }
        public int DaysAfter { get; set; }
        public string StartTime { get; set; }
        public int? DefaultMasterClipStatusId { get; set; }
    }
}
