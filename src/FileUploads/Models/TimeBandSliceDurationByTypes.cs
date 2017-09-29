using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandSliceDurationByTypes
    {
        public Guid Id { get; set; }
        public Guid TimeBandSliceDurationId { get; set; }
        public int TypeId { get; set; }
        public int Duration { get; set; }

        public virtual TimeBandSliceDurations TimeBandSliceDuration { get; set; }
        public virtual BookingTypes Type { get; set; }
    }
}
