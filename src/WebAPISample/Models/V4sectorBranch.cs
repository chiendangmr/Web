using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class V4sectorBranch
    {
        public int Id { get; set; }
        public int? SectorId { get; set; }
        public int? BranchId { get; set; }
        public int? PositionOrder { get; set; }

        public virtual V4branch Branch { get; set; }
        public virtual TblSectors Sector { get; set; }
    }
}
