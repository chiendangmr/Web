using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("ContentChannelLock_TimeBandBaseNoLocks", Schema = "Booking")]
    public class ContentChannelLock_TimeBandBaseNoLock
    {
        [Column("LockId")]
        public Guid ChannelLockId { get; set; }

        [ForeignKey(nameof(ChannelLockId))]
        public ContentChannelLock ChannelLock { get; set; }

        public Guid TimeBandBaseId { get; set; }

        [ForeignKey(nameof(TimeBandBaseId))]
        public TimeBandBase TimeBandBase { get; set; }
    }
}
