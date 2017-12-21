using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    /// <summary>
    /// Channel
    /// </summary>
    [Table("tblKenh")]
    public class Channel
    {
        /// <summary>
        /// Id of channel
        /// </summary>
        [Key]
        [Column("MaKenh")]
        public int Id { get; set; }

        /// <summary>
        /// Name of channel
        /// </summary>
        [Column("TenKenh")]
        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Timebands
        /// </summary>
        [ForeignKey(nameof(TimeBand.ChannelId))]
        public ICollection<TimeBand> TimeBands { get; } = new HashSet<TimeBand>();

        /// <summary>
        /// Content locks
        /// </summary>
        [ForeignKey(nameof(ContentChannelLock.ChannelId))]
        public ICollection<ContentChannelLock> ContentLocks { get; } = new HashSet<ContentChannelLock>();
    }
}
