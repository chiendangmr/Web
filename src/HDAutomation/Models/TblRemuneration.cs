using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblRemuneration
    {
        public int RemunerationId { get; set; }
        public double Valuation { get; set; }
        public int TblNewType { get; set; }
        public int TblJobs { get; set; }
    }
}
