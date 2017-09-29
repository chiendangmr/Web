using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBands
    {
        public TimeBands()
        {
            AssetTimeBandLocks = new HashSet<AssetTimeBandLocks>();
            BenefitPriceTimeBands = new HashSet<BenefitPriceTimeBands>();
            PositionRates = new HashSet<PositionRates>();
            TimeBandDays = new HashSet<TimeBandDays>();
            TimeBandDescriptions = new HashSet<TimeBandDescriptions>();
            TimeBandPrices = new HashSet<TimeBandPrices>();
            TimeBandSlices = new HashSet<TimeBandSlices>();
            TimeBandTimes = new HashSet<TimeBandTimes>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<AssetTimeBandLocks> AssetTimeBandLocks { get; set; }
        public virtual ICollection<BenefitPriceTimeBands> BenefitPriceTimeBands { get; set; }
        public virtual ICollection<PositionRates> PositionRates { get; set; }
        public virtual ICollection<TimeBandDays> TimeBandDays { get; set; }
        public virtual ICollection<TimeBandDescriptions> TimeBandDescriptions { get; set; }
        public virtual ICollection<TimeBandPrices> TimeBandPrices { get; set; }
        public virtual ICollection<TimeBandSlices> TimeBandSlices { get; set; }
        public virtual ICollection<TimeBandTimes> TimeBandTimes { get; set; }
        public virtual TimeBandBases IdNavigation { get; set; }
    }
}
