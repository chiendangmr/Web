using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgmedia
    {
        public long Cgid { get; set; }
        public string Cgdescription { get; set; }
        public string CgfileName { get; set; }
        public int? NasId { get; set; }
    }
}
