using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SpotBlock
    {
        public SpotBlock()
        {
            RateSpotBlocks = new HashSet<RateSpotBlock>();
            SpotBlockRates = new HashSet<SpotBlockRate>();
        }

        public Guid Id { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RateSpotBlock> RateSpotBlocks { get; set; }
        public virtual ICollection<SpotBlockRate> SpotBlockRates { get; set; }
		public virtual ICollection<TimeBandPrice> TimeBandPrices { get; set; }
	}
}
