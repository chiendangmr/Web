using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    /// <summary>
    /// Base of channel and timeband
    /// </summary>
    [Table("TimeBandBases", Schema = "System")]
    public class TimeBandBase
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        
        /// <summary>
        /// ParentId
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Parent channel or timeband
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public TimeBandBase Parent { get; set; }

        /// <summary>
        /// Childrens channel or timeband
        /// </summary>
        [ForeignKey(nameof(ParentId))]
        public ICollection<TimeBandBase> Childrens { get; } = new HashSet<TimeBandBase>();
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Is Channel
        /// </summary>
        [ForeignKey(nameof(Id))]
        public Channel Channel { get; set; }

        /// <summary>
        /// Is timeband
        /// </summary>
        [ForeignKey(nameof(Id))]
        public TimeBand TimeBand { get; set; }

        /// <summary>
        /// No lock when parent lock
        /// </summary>
        [ForeignKey(nameof(ContentChannelLock_TimeBandBaseNoLock.TimeBandBaseId))]
        public ICollection<ContentChannelLock_TimeBandBaseNoLock> NoLockInChannelLocks { get; } = new HashSet<ContentChannelLock_TimeBandBaseNoLock>();

        [ForeignKey(nameof(DiscountAnnexContract_TimeBandBase.TimeBandBaseId))]
        public ICollection<DiscountAnnexContract_TimeBandBase> DiscountAnnexContracts { get; } = new HashSet<DiscountAnnexContract_TimeBandBase>();
    }
}
