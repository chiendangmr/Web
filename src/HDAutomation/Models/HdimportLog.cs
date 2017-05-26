using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class HdimportLog
    {
        public long Id { get; set; }
        public long Idclip { get; set; }
        public long IdImport { get; set; }
        public string MaBang { get; set; }
        public string FileSource { get; set; }
        public DateTime LogTime { get; set; }
        public string Log { get; set; }
    }
}
