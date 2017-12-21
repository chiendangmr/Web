using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class PositionRate
    {
        public Guid Id { get; set; }
        public Guid? TimeBandId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rate { get; set; }

        public virtual TimeBand TimeBand { get; set; }
    }
}
