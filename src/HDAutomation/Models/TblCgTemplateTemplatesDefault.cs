using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblCgTemplateTemplatesDefault
    {
        public int Id { get; set; }
        public int CgtemplateTemplateId { get; set; }
        public string CganchorTime { get; set; }
        public int? AnchorType { get; set; }
        public int? StartCommand { get; set; }
        public int? FadeInDur { get; set; }
        public string CgendAnchorTime { get; set; }
        public int? EndAnchorType { get; set; }
        public int? EndCommand { get; set; }
        public int? FadeOutDur { get; set; }
        public int? CgnumberInClip { get; set; }
        public string CgspaceInClip { get; set; }

        public virtual TblCgTemplateTemplates CgtemplateTemplate { get; set; }
    }
}
