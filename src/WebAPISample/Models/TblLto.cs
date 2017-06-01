using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblLto
    {
        public long LtoId { get; set; }
        public string TapeName { get; set; }
        public DateTime? TapeCreatedDate { get; set; }
        public decimal? FreeSpace { get; set; }
        public string TapeLocation { get; set; }
        public int? TapeTypeId { get; set; }
        public string TapeQuality { get; set; }
        public int? Changed { get; set; }
    }
}
