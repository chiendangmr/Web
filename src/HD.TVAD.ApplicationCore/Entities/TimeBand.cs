using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBand
    {
        public TimeBand()
        {
            ContentTimeBandLocks = new HashSet<ContentTimeBandLock>();
            PositionRates = new HashSet<PositionRate>();
            TimeBandDays = new HashSet<TimeBandDay>();
            TimeBandDescriptions = new HashSet<TimeBandDescription>();
            TimeBandPrices = new HashSet<TimeBandPrice>();
            TimeBandSlices = new HashSet<TimeBandSlice>();
            TimeBandTimes = new HashSet<TimeBandTime>();
			BenefitPriceTimeBands = new HashSet<BenefitPriceTimeBand>();

		}

        public Guid Id { get; set; }

        public virtual ICollection<ContentTimeBandLock> ContentTimeBandLocks { get; set; }
        public virtual ICollection<PositionRate> PositionRates { get; set; }
        public virtual ICollection<TimeBandDay> TimeBandDays { get; set; }
        public virtual ICollection<TimeBandDescription> TimeBandDescriptions { get; set; }
        public virtual ICollection<TimeBandPrice> TimeBandPrices { get; set; }
        public virtual ICollection<TimeBandSlice> TimeBandSlices { get; set; }
        public virtual ICollection<TimeBandTime> TimeBandTimes { get; set; }
		public virtual ICollection<BenefitPriceTimeBand> BenefitPriceTimeBands { get; set; }		
		public virtual TimeBandBase TimeBandBase { get; set; }


		public string TimeBandName { get {
				return TimeBandBase.Name;
			} }
	}
}
