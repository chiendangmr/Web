using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgTemplateComponents
    {
        public long Id { get; set; }
        public int? TemplateId { get; set; }
        public int? ComponentId { get; set; }
    }
}
