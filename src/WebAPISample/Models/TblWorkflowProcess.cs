using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblWorkflowProcess
    {
        public int WorkflowProcessId { get; set; }
        public int WorkflowId { get; set; }
        public int ProcessId { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public int? SizeX { get; set; }
        public int? SizeY { get; set; }
    }
}
