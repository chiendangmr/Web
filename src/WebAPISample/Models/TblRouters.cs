using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblRouters
    {
        public int RouterId { get; set; }
        public string RouterName { get; set; }
        public string ControlIpAddress { get; set; }
        public int? ControlPort { get; set; }
        public string DataIpAddress { get; set; }
        public int? DataPort { get; set; }
        public string ClassName { get; set; }
        public string RouterDllName { get; set; }
    }
}
