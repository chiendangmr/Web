using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandSliceDurationByType
    {
        public Guid Id { get; set; }
        public Guid TimeBandSliceDurationId { get; set; }
        public int TypeId { get; set; }
        public int Duration { get; set; }

        public virtual TimeBandSliceDuration TimeBandSliceDuration { get; set; }
        public virtual BookingType Type { get; set; }
    }
}
