using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandBase
    {
        public TimeBandBase()
        {
            AssetChannelLockTimeBandBaseNoLocks = new HashSet<ContentChannelLockTimeBandBaseNoLock>();
            DiscountAnnexContractTimeBandBases = new HashSet<DiscountAnnexContractTimeBandBase>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<ContentChannelLockTimeBandBaseNoLock> AssetChannelLockTimeBandBaseNoLocks { get; set; }
        public virtual Channel Channels { get; set; }
        public virtual ICollection<DiscountAnnexContractTimeBandBase> DiscountAnnexContractTimeBandBases { get; set; }
		public virtual ICollection<TimeBandBaseScheduleTemplate> TimeBandBaseScheduleTemplates { get; set; }
		
		public virtual TimeBand TimeBands { get; set; }
        public virtual TimeBandBase Parent { get; set; }
        public virtual ICollection<TimeBandBase> InverseParent { get; set; }
    }
}
