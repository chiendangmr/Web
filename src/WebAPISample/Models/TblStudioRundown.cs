using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblStudioRundown
    {
        public long NewsId { get; set; }
        public string AuxiliaryEventTime { get; set; }
        public int AuxiliaryEventTypeId { get; set; }
        public string AuxiliaryCommand { get; set; }
        public long Id { get; set; }
    }
}
