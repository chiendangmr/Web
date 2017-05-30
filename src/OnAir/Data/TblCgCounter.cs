using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblCgCounter
    {
        public long Id { get; set; }
        public string Format { get; set; }
        public bool Invert { get; set; }
        public double Increase { get; set; }
    }
}
