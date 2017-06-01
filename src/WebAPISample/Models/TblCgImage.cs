using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgImage
    {
        public long Id { get; set; }
        public int NasId { get; set; }
        public string Path { get; set; }
    }
}
