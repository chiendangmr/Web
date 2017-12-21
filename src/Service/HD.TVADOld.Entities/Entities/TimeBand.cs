using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVADOld.Entities.Entities
{
    [Table("tblMaGio")]
    public class TimeBand
    {
        [Column("IDMaGio")]
        public int Id { get; set; }

        [Column("TenMaGio")]
        [StringLength(20)]
        [Required]
        public string Name { get; set; }

        [Column("MaKenh")]
        public int ChannelId { get; set; }

        [ForeignKey(nameof(ChannelId))]
        public Channel Channel { get; set; }

        [Column("GioBatDau")]
        public DateTime? StartTimeOfDay { get; set; }

        [Column("GioKetThuc")]
        public DateTime? EndTimeOfDay { get; set; }

        [Column("NgayPhatSong")]
        public DayOfWeek? DayOfWeeks { get; set; }

        [Column("DienGiai")]
        public string Description { get; set; }

        /// <summary>
        /// Descriptions
        /// </summary>
        [ForeignKey(nameof(TimeBandDescription.TimeBandId))]
        public ICollection<TimeBandDescription> Descriptions { get; } = new HashSet<TimeBandDescription>();

        /// <summary>
        /// Slices
        /// </summary>
        [ForeignKey(nameof(TimeBandSlice.TimeBandId))]
        public ICollection<TimeBandSlice> Slices { get; } = new HashSet<TimeBandSlice>();

        /// <summary>
        /// Prices
        /// </summary>
        [ForeignKey(nameof(TimeBandPrice.TimeBandId))]
        public ICollection<TimeBandPrice> Prices { get; } = new HashSet<TimeBandPrice>();

        /// <summary>
        /// Position rates
        /// </summary>
        [ForeignKey(nameof(TimeBandPositionRate.TimeBandId))]
        public ICollection<TimeBandPositionRate> PositionRates { get; } = new HashSet<TimeBandPositionRate>();

        /// <summary>
        /// Content locks
        /// </summary>
        [ForeignKey(nameof(ContentTimeBandLock.TimeBandId))]
        public ICollection<ContentTimeBandLock> ContentLocks { get; } = new HashSet<ContentTimeBandLock>();

        [ForeignKey(nameof(ContentChannelLock_TimeBandNoLock.TimeBandId))]
        public ICollection<ContentChannelLock_TimeBandNoLock> NoLockInContentChannelLocks { get; } = new HashSet<ContentChannelLock_TimeBandNoLock>();

        [ForeignKey(nameof(DiscountAnnexContractPartnerByTimeBand.TimeBandId))]
        public ICollection<DiscountAnnexContractPartnerByTimeBand> DiscountAnnexContracts { get; } = new HashSet<DiscountAnnexContractPartnerByTimeBand>();

        [ForeignKey(nameof(AnnexContractPartnerPrice_TimeBand.TimeBandId))]
        public ICollection<AnnexContractPartnerPrice_TimeBand> AnnexContractPartnerPrices { get; } = new HashSet<AnnexContractPartnerPrice_TimeBand>();
    }

    public enum DayOfWeek : byte
    {
        None = 0,
        Monday = 1 << 0,
        Tuesday = 1 << 1,
        Wednesday = 1 << 2,
        Thursday = 1 << 3,
        Friday = 1 << 4,
        Saturday = 1 << 5,
        Sunday = 1 << 6
    }
}
