using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandSliceDescription
    {
        public Guid Id { get; set; }
        public Guid TimeBandSliceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        public virtual TimeBandSlice TimeBandSlice { get; set; }
    }
}
