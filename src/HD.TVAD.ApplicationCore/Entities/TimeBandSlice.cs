using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandSlice
    {
        public TimeBandSlice()
        {
            Spots = new HashSet<Spot>();
            TimeBandSliceDescriptions = new HashSet<TimeBandSliceDescription>();
            TimeBandSliceDurations = new HashSet<TimeBandSliceDuration>();
            TimeBandSliceForTypes = new HashSet<TimeBandSliceForType>();
        }

        public Guid Id { get; set; }
        public Guid TimeBandId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Spot> Spots { get; set; }
        public virtual ICollection<TimeBandSliceDescription> TimeBandSliceDescriptions { get; set; }
        public virtual ICollection<TimeBandSliceDuration> TimeBandSliceDurations { get; set; }
        public virtual ICollection<TimeBandSliceForType> TimeBandSliceForTypes { get; set; }
        public virtual TimeBand TimeBand { get; set; }
    }
}
