using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgTemplateTemplates
    {
        public TblCgTemplateTemplates()
        {
            TblCglayer = new HashSet<TblCglayer>();
            TblCgTemplateTemplatePropertyValue = new HashSet<TblCgTemplateTemplatePropertyValue>();
            TblCgTemplateTemplatesDefault = new HashSet<TblCgTemplateTemplatesDefault>();
        }

        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public int? SectorId { get; set; }
        public string CganchorTime { get; set; }
        public int? AnchorType { get; set; }
        public int? StartCommand { get; set; }
        public int? FadeInDur { get; set; }
        public string CgendAnchorTime { get; set; }
        public int? EndAnchorType { get; set; }
        public int? EndCommand { get; set; }
        public int? FadeOutDur { get; set; }
        public bool? OffWhenEndClip { get; set; }
        public int? CgnumberInClip { get; set; }
        public string CgspaceInClip { get; set; }

        public virtual ICollection<TblCglayer> TblCglayer { get; set; }
        public virtual ICollection<TblCgTemplateTemplatePropertyValue> TblCgTemplateTemplatePropertyValue { get; set; }
        public virtual ICollection<TblCgTemplateTemplatesDefault> TblCgTemplateTemplatesDefault { get; set; }
        public virtual TblCgTemplates Template { get; set; }
    }
}
