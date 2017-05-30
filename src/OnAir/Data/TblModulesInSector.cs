using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblModulesInSector
    {
        public int Id { get; set; }
        public int? SectorId { get; set; }
        public int ModuleId { get; set; }
        public int ModuleStatus { get; set; }
        public int? ControllerServerId { get; set; }
    }
}
