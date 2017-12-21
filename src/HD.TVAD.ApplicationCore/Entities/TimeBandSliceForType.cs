using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandSliceForType
    {
        public Guid Id { get; set; }
        public Guid TimeBandSliceId { get; set; }
        public int TypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual TimeBandSlice TimeBandSlice { get; set; }
        public virtual BookingType Type { get; set; }
    }
}
