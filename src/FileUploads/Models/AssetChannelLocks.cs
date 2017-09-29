using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AssetChannelLocks
    {
        public AssetChannelLocks()
        {
            AssetChannelLockTimeBandBaseNoLocks = new HashSet<AssetChannelLockTimeBandBaseNoLocks>();
        }

        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<AssetChannelLockTimeBandBaseNoLocks> AssetChannelLockTimeBandBaseNoLocks { get; set; }
        public virtual Content Asset { get; set; }
        public virtual Channels Channel { get; set; }
    }
}
