using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandPrice
    {
        public Guid Id { get; set; }
        public Guid TimeBandId { get; set; }
        public Guid? SpotBlockId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }

        public virtual SpotBlock SpotBlock { get; set; }
        public virtual TimeBand TimeBand { get; set; }
    }
}
