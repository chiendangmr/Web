using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgserver
    {
        public int CgserverId { get; set; }
        public string CgserverName { get; set; }
        public string CgserverDescription { get; set; }
        public string Cgipaddress { get; set; }
        public int CgcontrolPort { get; set; }
        public int? CginputPort { get; set; }
        public int? CginputRouterId { get; set; }
        public int? CgoutputPort { get; set; }
        public int? CgoutputRouterId { get; set; }
        public int? Status { get; set; }
        public string CgclassName { get; set; }
        public string CgdllName { get; set; }       
    }
}
