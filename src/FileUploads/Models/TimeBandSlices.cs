using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandSlices
    {
        public TimeBandSlices()
        {
            Spots = new HashSet<Spots>();
            TimeBandSliceDescriptions = new HashSet<TimeBandSliceDescriptions>();
            TimeBandSliceDurations = new HashSet<TimeBandSliceDurations>();
            TimeBandSliceForTypes = new HashSet<TimeBandSliceForTypes>();
        }

        public Guid Id { get; set; }
        public Guid TimeBandId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Spots> Spots { get; set; }
        public virtual ICollection<TimeBandSliceDescriptions> TimeBandSliceDescriptions { get; set; }
        public virtual ICollection<TimeBandSliceDurations> TimeBandSliceDurations { get; set; }
        public virtual ICollection<TimeBandSliceForTypes> TimeBandSliceForTypes { get; set; }
        public virtual TimeBands TimeBand { get; set; }
    }
}
