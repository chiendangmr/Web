using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblNewsCheck
    {
        public long NewsId { get; set; }
        public int CheckLevelId { get; set; }
        public int? CheckerId { get; set; }
        public string CheckerComment { get; set; }
        public int? CheckStatus { get; set; }
        public DateTime? CheckDate { get; set; }
        public long Id { get; set; }
    }
}
