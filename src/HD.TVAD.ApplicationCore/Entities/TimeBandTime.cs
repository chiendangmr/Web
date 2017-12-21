using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandTime
    {
        public Guid Id { get; set; }
        public Guid TimeBandId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan StartTimeOfDay { get; set; }
        public int Duration { get; set; }

        public virtual TimeBand TimeBand { get; set; }
    }
}
