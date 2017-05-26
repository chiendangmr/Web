using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblCgmedia
    {
        public long Cgid { get; set; }
        public string Cgdescription { get; set; }
        public string CgfileName { get; set; }
        public int? NasId { get; set; }
    }
}
