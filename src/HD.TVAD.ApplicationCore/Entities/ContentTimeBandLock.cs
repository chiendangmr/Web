using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class ContentTimeBandLock
    {
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public Guid TimeBandId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Content Content { get; set; }
        public virtual TimeBand TimeBand { get; set; }
    }
}
