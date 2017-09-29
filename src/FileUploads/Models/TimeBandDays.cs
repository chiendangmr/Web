using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandDays
    {
        public Guid Id { get; set; }
        public Guid TimeBandId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DayOfWeeks { get; set; }

        public virtual TimeBands TimeBand { get; set; }
    }
}
