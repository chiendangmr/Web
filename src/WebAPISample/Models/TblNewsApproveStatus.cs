using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblNewsApproveStatus
    {
        public int StatusId { get; set; }
        public string Description { get; set; }
        public int? StatusName { get; set; }
    }
}
