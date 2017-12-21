using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Template
    {
        public Template()
        {
            TemplateItems = new HashSet<TemplateItem>();
            TimeBandBaseScheduleTemplates = new HashSet<TimeBandBaseScheduleTemplate>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TemplateItem> TemplateItems { get; set; }
        public virtual ICollection<TimeBandBaseScheduleTemplate> TimeBandBaseScheduleTemplates { get; set; }
    }
}
