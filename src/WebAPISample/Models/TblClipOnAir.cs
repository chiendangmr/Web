using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblClipOnAir
    {
        public long IdClip { get; set; }
        public DateTime OnAirTime { get; set; }
        public int SectorId { get; set; }
        public string PlayTcIn { get; set; }
        public string PlayTcOut { get; set; }
        public long Id { get; set; }
    }
}
