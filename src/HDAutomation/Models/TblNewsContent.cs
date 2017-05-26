using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblNewsContent
    {
        public long ContentId { get; set; }
        public long NewsId { get; set; }
        public string PrompterText { get; set; }
        public string VoiceOverText { get; set; }
        public int? CheckerId { get; set; }
        public DateTime Date { get; set; }
    }
}
