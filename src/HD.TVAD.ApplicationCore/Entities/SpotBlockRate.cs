using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SpotBlockRate
    {
        public SpotBlockRate()
        {
          //  TimeBandPrices = new HashSet<TimeBandPrice>();
        }

        public Guid Id { get; set; }
        public Guid SpotBlockId { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }

      //  public virtual ICollection<TimeBandPrice> TimeBandPrices { get; set; }
        public virtual SpotBlock SpotBlock { get; set; }
    }
}
