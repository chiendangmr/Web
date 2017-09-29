using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandBases
    {
        public TimeBandBases()
        {
            AssetChannelLockTimeBandBaseNoLocks = new HashSet<AssetChannelLockTimeBandBaseNoLocks>();
            DiscountAnnexContractTimeBandBases = new HashSet<DiscountAnnexContractTimeBandBases>();
            TimeBandBaseScheduleTemplates = new HashSet<TimeBandBaseScheduleTemplates>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<AssetChannelLockTimeBandBaseNoLocks> AssetChannelLockTimeBandBaseNoLocks { get; set; }
        public virtual Channels Channels { get; set; }
        public virtual ICollection<DiscountAnnexContractTimeBandBases> DiscountAnnexContractTimeBandBases { get; set; }
        public virtual ICollection<TimeBandBaseScheduleTemplates> TimeBandBaseScheduleTemplates { get; set; }
        public virtual TimeBands TimeBands { get; set; }
        public virtual TimeBandBases Parent { get; set; }
        public virtual ICollection<TimeBandBases> InverseParent { get; set; }
    }
}
