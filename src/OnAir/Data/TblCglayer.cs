using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblCglayer
    {
        public TblCglayer()
        {
            TblCgPlaylistItem = new HashSet<TblCgPlaylistItem>();
            TblClipTypeCglayer = new HashSet<TblClipTypeCglayer>();
        }

        public int CglayerId { get; set; }
        public int CglayerIndex { get; set; }
        public int CgtemplateTemplateId { get; set; }

        public virtual ICollection<TblCgPlaylistItem> TblCgPlaylistItem { get; set; }
        public virtual ICollection<TblClipTypeCglayer> TblClipTypeCglayer { get; set; }
        public virtual TblCgTemplateTemplates CgtemplateTemplate { get; set; }
    }
}
