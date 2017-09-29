using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandBaseScheduleTemplates
    {
        public Guid Id { get; set; }
        public Guid TimeBandBaseId { get; set; }
        public Guid ScheduleTemplateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Templates ScheduleTemplate { get; set; }
        public virtual TimeBandBases TimeBandBase { get; set; }
    }
}
