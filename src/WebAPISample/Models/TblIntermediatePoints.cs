using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblIntermediatePoints
    {
        public int ConnectionId { get; set; }
        public int IntermediatePointId { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public int Id { get; set; }
    }
}
