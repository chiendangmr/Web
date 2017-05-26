using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblCgCounter
    {
        public long Id { get; set; }
        public string Format { get; set; }
        public bool Invert { get; set; }
        public double Increase { get; set; }
    }
}
