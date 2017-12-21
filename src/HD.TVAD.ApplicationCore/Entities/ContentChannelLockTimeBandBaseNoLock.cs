using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class ContentChannelLockTimeBandBaseNoLock
    {
        public Guid LockId { get; set; }
        public Guid TimeBandBaseId { get; set; }

        public virtual ContentChannelLock Lock { get; set; }
        public virtual TimeBandBase TimeBandBase { get; set; }
    }
}
