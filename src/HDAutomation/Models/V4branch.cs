using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class V4branch
    {
        public V4branch()
        {
            V4sectorBranch = new HashSet<V4sectorBranch>();
        }

        public int BranchId { get; set; }
        public int? OperateServerId { get; set; }
        public int? Cgid { get; set; }
        public int? Mscid { get; set; }

        public virtual ICollection<V4sectorBranch> V4sectorBranch { get; set; }
        public virtual TblCgserver Cg { get; set; }
        public virtual TblMcsservers Msc { get; set; }
        public virtual TblOperateServers OperateServer { get; set; }
    }
}
