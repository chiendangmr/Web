using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgTemplateTemplatePropertyValue
    {
        public int Id { get; set; }
        public int TemplateTemplateId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual TblCgTemplateTemplates TemplateTemplate { get; set; }
    }
}
