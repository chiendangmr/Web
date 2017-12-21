using System;

namespace HD.TVAD.Web.Models
{
    public class TimeBandLockViewModel
    {
        public Guid? Id { get; set; }
        public Guid? ContentId { get; set; }
        public Guid? TimeBandId { get; set; }
        public string TimeBandName { get; set; }
        public DateTime? StartDate { get; set; }   
        public DateTime? EndDate { get; set; }

    }
}