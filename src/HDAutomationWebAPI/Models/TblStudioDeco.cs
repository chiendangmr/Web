using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblStudioDeco
    {
        public int Id { get; set; }
        public int? StudioId { get; set; }
        public int? DecoId { get; set; }
        public DateTime? DecoDate { get; set; }
    }
}
