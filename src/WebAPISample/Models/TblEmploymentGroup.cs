using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblEmploymentGroup
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int JobTitleId { get; set; }
        public int DeparmentId { get; set; }
        public int? GranterId { get; set; }
    }
}
