using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Channel
    {
        public Channel()
        {
            AssetChannelLocks = new HashSet<ContentChannelLock>();
            Evidences = new HashSet<Evidence>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<ContentChannelLock> AssetChannelLocks { get; set; }
        public virtual TimeBandBase TimeBandBase { get; set; }
        public virtual ICollection<Evidence> Evidences { get; set; }
    }
}
