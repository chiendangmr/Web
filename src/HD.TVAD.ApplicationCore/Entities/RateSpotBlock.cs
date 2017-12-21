using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class RateSpotBlock
    {
        public Guid Id { get; set; }
        public Guid SpotBlockId { get; set; }
        public decimal? Rate { get; set; }

        public virtual TypeDetail TypeDetail { get; set; }
        public virtual SpotBlock SpotBlock { get; set; }
    }
}
