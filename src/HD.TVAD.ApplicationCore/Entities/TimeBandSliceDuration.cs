using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandSliceDuration
    {
        public TimeBandSliceDuration()
        {
            TimeBandSliceDurationByTypes = new HashSet<TimeBandSliceDurationByType>();
        }

        public Guid Id { get; set; }
        public Guid TimeBandSliceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<TimeBandSliceDurationByType> TimeBandSliceDurationByTypes { get; set; }
        public virtual TimeBandSlice TimeBandSlice { get; set; }
    }
}
