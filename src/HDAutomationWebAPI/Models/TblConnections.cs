using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblConnections
    {
        public int ConnectId { get; set; }
        public int? WorkflowProcessStartId { get; set; }
        public int? WorkflowProcessEndId { get; set; }
        public int? StartPointX { get; set; }
        public int? StartPointY { get; set; }
        public int? EndPointX { get; set; }
        public int? EndPointY { get; set; }
    }
}
