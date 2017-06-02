using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblSectors
    {
        public TblSectors()
        {           
            TblClipTypes = new HashSet<TblClipTypes>();            
        }

        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public int? OperateServerId1 { get; set; }
        public int? OperateServerId2 { get; set; }
        public int? OperateServerId3 { get; set; }
        public int? OperateServerId4 { get; set; }
        public int? OriginOperateServerId1 { get; set; }
        public int? OriginOperateServerId2 { get; set; }
        public int? OriginOperateServerId3 { get; set; }
        public int? OriginOperateServerId4 { get; set; }
        public int? WindowX { get; set; }
        public int? WindowY { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? AutoOnAir { get; set; }
        public int? LiveInput { get; set; }
        public int? RouterId { get; set; }
        public string CgipAddress { get; set; }
        public int? Cgport { get; set; }
        public int? OperatingMode { get; set; }
        public int? CurrentCgserverId { get; set; }
        public int? Changed { get; set; }
        public int? CurrentCgserverId2 { get; set; }
        public int? Mcsid1 { get; set; }
        public int? Mcsid2 { get; set; }
        public int? PlayingState { get; set; }
        public Guid? SyncId { get; set; }
        public int MasterBranchId { get; set; }
        
        public virtual ICollection<TblClipTypes> TblClipTypes { get; set; }       
    }
}
