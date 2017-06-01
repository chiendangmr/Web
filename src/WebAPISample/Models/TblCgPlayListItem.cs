using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgPlaylistItem
    {
        public long CgItemId { get; set; }
        public long? PlaylistItemId { get; set; }
        public string CganchorTime { get; set; }
        public int AnchorType { get; set; }
        public int Layer { get; set; }
        public int? CgtemplateTemplateId { get; set; }
        public int StartCommand { get; set; }
        public int EndCommand { get; set; }
        public int FadeInDur { get; set; }
        public int FadeOutDur { get; set; }
        public string ConfigTemplateParams { get; set; }
        public string Duration { get; set; }
        public string Name { get; set; }
        public bool OffWhenEndClip { get; set; }
        public int CglayerId { get; set; }

        public virtual TblCglayer Cglayer { get; set; }
    }
}
