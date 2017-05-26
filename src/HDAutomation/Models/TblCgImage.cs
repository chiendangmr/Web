using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblCgImage
    {
        public long Id { get; set; }
        public int NasId { get; set; }
        public string Path { get; set; }
    }
}
