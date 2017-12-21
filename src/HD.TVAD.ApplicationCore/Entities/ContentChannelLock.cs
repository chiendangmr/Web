using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class ContentChannelLock
    {
        public ContentChannelLock()
        {
            ContentChannelLockTimeBandBaseNoLocks = new HashSet<ContentChannelLockTimeBandBaseNoLock>();
        }

        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<ContentChannelLockTimeBandBaseNoLock> ContentChannelLockTimeBandBaseNoLocks { get; set; }
        public virtual Content Content { get; set; }
        public virtual Channel Channel { get; set; }
    }
}
