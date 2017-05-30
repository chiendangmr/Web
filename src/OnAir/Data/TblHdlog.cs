using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblHdlog
    {
        public long Id { get; set; }
        public int? SectorId { get; set; }
        public int? ModuleId { get; set; }
        public DateTime? LogTime { get; set; }
        public string LogMessage { get; set; }
        public int? LogLevel { get; set; }
        public int? LogCategory { get; set; }
    }
}
