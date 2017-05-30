using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblAsRunLog
    {
        public long PlayLogsId { get; set; }
        public DateTime PlayTime { get; set; }
        public int ListId { get; set; }
        public long IdClip { get; set; }
        public string TapeId { get; set; }
        public string ProgramName { get; set; }
        public string PlayTcIn { get; set; }
        public string PlayTcOut { get; set; }
        public bool? HaveSync { get; set; }
        public long? ItemId { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Result { get; set; }
    }
}
