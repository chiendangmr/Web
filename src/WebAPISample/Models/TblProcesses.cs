using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblProcesses
    {
        public int ProcessId { get; set; }
        public int? ShapeId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
    }
}
