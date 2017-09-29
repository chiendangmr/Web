using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandSliceForTypes
    {
        public Guid Id { get; set; }
        public Guid TimeBandSliceId { get; set; }
        public int TypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual TimeBandSlices TimeBandSlice { get; set; }
        public virtual BookingTypes Type { get; set; }
    }
}
