using System;
using System.Collections.Generic;

namespace OnAir.Data
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
