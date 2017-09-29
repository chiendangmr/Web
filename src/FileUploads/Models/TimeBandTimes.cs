using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandTimes
    {
        public Guid Id { get; set; }
        public Guid TimeBandId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan StartTimeOfDay { get; set; }
        public int Duration { get; set; }

        public virtual TimeBands TimeBand { get; set; }
    }
}
