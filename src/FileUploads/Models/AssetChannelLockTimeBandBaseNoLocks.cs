using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AssetChannelLockTimeBandBaseNoLocks
    {
        public Guid LockId { get; set; }
        public Guid TimeBandBaseId { get; set; }

        public virtual AssetChannelLocks Lock { get; set; }
        public virtual TimeBandBases TimeBandBase { get; set; }
    }
}
