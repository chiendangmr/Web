using HD.TVAD.Entities.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    /// <summary>
    /// Channel
    /// </summary>
    [Table("Channels", Schema = "System")]
    public class Channel
    {
        /// <summary>
        /// ID of channel
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Base object
        /// </summary>
        [ForeignKey(nameof(Id))]
        public TimeBandBase TimeBandBase { get; set; }

        /// <summary>
        /// Id in old system
        /// </summary>
        public int? OldId { get; set; }

        /// <summary>
        /// Content locks
        /// </summary>
        [ForeignKey(nameof(ContentChannelLock.ChannelId))]
        public ICollection<ContentChannelLock> ContentLocks { get; } = new HashSet<ContentChannelLock>();

        public Channel()
        {
            TimeBandBase = new TimeBandBase
            {
                Id = this.Id,
                Channel = this
            };
        }
    }
}
