using HD.TVAD.Entities.Entities.MediaAsset;
using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("ContentChannelLocks", Schema = "Booking")]
    public class ContentChannelLock
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ContentId { get; set; }

        [ForeignKey(nameof(ContentId))]
        public Content Content { get; set; }

        public Guid ChannelId { get; set; }

        [ForeignKey(nameof(ChannelId))]
        public Channel Channel { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Channel or timeband childrens no lock
        /// </summary>
        [ForeignKey(nameof(ContentChannelLock_TimeBandBaseNoLock.ChannelLockId))]
        public ICollection<ContentChannelLock_TimeBandBaseNoLock> ChildrenNoLocks { get; } = new HashSet<ContentChannelLock_TimeBandBaseNoLock>();
    }
}
