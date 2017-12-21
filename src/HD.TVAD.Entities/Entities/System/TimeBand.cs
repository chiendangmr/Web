using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    [Table("TimeBands", Schema = "System")]
    public class TimeBand
    {
        /// <summary>
        /// Id of timeband
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Base  object
        /// </summary>
        [ForeignKey(nameof(Id))]
        public TimeBandBase TimeBandBase { get; set; }

        /// <summary>
        /// Start time of day
        /// </summary>
        [ForeignKey(nameof(TimeBandTime.TimeBandId))]
        public ICollection<TimeBandTime> TimeOfDays { get; } = new HashSet<TimeBandTime>();

        /// <summary>
        /// Description by date
        /// </summary>
        [ForeignKey(nameof(TimeBandDescription.TimeBandId))]
        public ICollection<TimeBandDescription> Descriptions { get; } = new HashSet<TimeBandDescription>();

        /// <summary>
        /// Day of weeks
        /// </summary>
        [ForeignKey(nameof(TimeBandDay.TimeBandId))]
        public ICollection<TimeBandDay> DayOfWeeks { get; } = new HashSet<TimeBandDay>();

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
        [ForeignKey(nameof(PositionRate.TimeBandId))]
        public ICollection<PositionRate> PositionRates { get; } = new HashSet<PositionRate>();

        /// <summary>
        /// Contents lock
        /// </summary>
        [ForeignKey(nameof(ContentTimeBandLock.TimeBandId))]
        public ICollection<ContentTimeBandLock> ContentLocks { get; } = new HashSet<ContentTimeBandLock>();

        [ForeignKey(nameof(BenefitPrice_TimeBand.TimeBandId))]
        public ICollection<BenefitPrice_TimeBand> BenefitPrices { get; } = new HashSet<BenefitPrice_TimeBand>();

        [ForeignKey(nameof(AnnexContractPrice_TimeBand.TimeBandId))]
        public ICollection<AnnexContractPrice_TimeBand> AnnexContractPrices { get; } = new HashSet<AnnexContractPrice_TimeBand>();

        /// <summary>
        /// Id in old system
        /// </summary>
        public int? OldId { get; set; }

        public TimeBand()
        {
            TimeBandBase = new TimeBandBase
            {
                Id = this.Id,
                TimeBand = this
            };
        }
    }
}
