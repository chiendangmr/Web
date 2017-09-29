using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SpotBlocks
    {
        public SpotBlocks()
        {
            RateSpotBlocks = new HashSet<RateSpotBlocks>();
            SpotBlockRates = new HashSet<SpotBlockRates>();
            TimeBandPrices = new HashSet<TimeBandPrices>();
        }

        public Guid Id { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RateSpotBlocks> RateSpotBlocks { get; set; }
        public virtual ICollection<SpotBlockRates> SpotBlockRates { get; set; }
        public virtual ICollection<TimeBandPrices> TimeBandPrices { get; set; }
    }
}
