using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblCgEvent
    {
        public long Id { get; set; }
        public int SectorId { get; set; }
        public int StartMode { get; set; }
        public int EndMode { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? StartByPlaylistItemId { get; set; }
        public long? EndByPlaylistItemId { get; set; }
        public long CgitemId { get; set; }
    }
}
