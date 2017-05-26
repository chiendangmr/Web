using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblServicesModule
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int HeartBeatPort { get; set; }
        public int HeartBeatInterval { get; set; }
        public int HeartBeatTimeOut { get; set; }
    }
}
