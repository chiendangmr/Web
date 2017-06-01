using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgTemplates
    {
        public TblCgTemplates()
        {
            TblCgTemplateTemplates = new HashSet<TblCgTemplateTemplates>();
        }

        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string TemplateFileName { get; set; }
        public int NasId { get; set; }
        public int IsServer { get; set; }
        public int Duration { get; set; }
        public int TemplateType { get; set; }

        public virtual ICollection<TblCgTemplateTemplates> TblCgTemplateTemplates { get; set; }
    }
}
