using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TimeBandBaseScheduleTemplate
    {
        public Guid Id { get; set; }
        public Guid TimeBandBaseId { get; set; }
        public Guid ScheduleTemplateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Template ScheduleTemplate { get; set; }
        public virtual TimeBandBase TimeBandBase { get; set; }
    }
}
