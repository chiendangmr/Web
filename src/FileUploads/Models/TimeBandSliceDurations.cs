using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandSliceDurations
    {
        public TimeBandSliceDurations()
        {
            TimeBandSliceDurationByTypes = new HashSet<TimeBandSliceDurationByTypes>();
        }

        public Guid Id { get; set; }
        public Guid TimeBandSliceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<TimeBandSliceDurationByTypes> TimeBandSliceDurationByTypes { get; set; }
        public virtual TimeBandSlices TimeBandSlice { get; set; }
    }
}
