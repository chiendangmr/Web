using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Templates
    {
        public Templates()
        {
            TemplateItems = new HashSet<TemplateItems>();
            TimeBandBaseScheduleTemplates = new HashSet<TimeBandBaseScheduleTemplates>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TemplateItems> TemplateItems { get; set; }
        public virtual ICollection<TimeBandBaseScheduleTemplates> TimeBandBaseScheduleTemplates { get; set; }
    }
}
