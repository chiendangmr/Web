using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandSliceDescriptions
    {
        public Guid Id { get; set; }
        public Guid TimeBandSliceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        public virtual TimeBandSlices TimeBandSlice { get; set; }
    }
}
