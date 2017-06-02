﻿using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblClipTypes
    {
        public TblClipTypes()
        {           
            TblClipTypeCglayer = new HashSet<TblClipTypeCglayer>();
        }

        public int TypeId { get; set; }
        public string TypeDescription { get; set; }
        public int? VoiceOverTrack { get; set; }
        public string ShortName { get; set; }
        public int? SectorId { get; set; }
        public int? Changed { get; set; }
        public string EvenRowColor { get; set; }
        public string OddRowColor { get; set; }
        public bool? Tvad { get; set; }
        public Guid SyncId { get; set; }
        public int? ChangedPcd { get; set; }
        
        public virtual ICollection<TblClipTypeCglayer> TblClipTypeCglayer { get; set; }
        public virtual TblSectors Sector { get; set; }
    }
}
