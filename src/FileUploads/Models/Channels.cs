using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Channels
    {
        public Channels()
        {
            AssetChannelLocks = new HashSet<AssetChannelLocks>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<AssetChannelLocks> AssetChannelLocks { get; set; }
        public virtual TimeBandBases IdNavigation { get; set; }
    }
}
