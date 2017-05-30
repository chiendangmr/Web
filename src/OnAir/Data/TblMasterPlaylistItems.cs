using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblMasterPlaylistItems
    {
        public long MasterPlaylistItemId { get; set; }
        public int? MasterPlaylistId { get; set; }
        public int MasterClipId { get; set; }
        public string MasterClipPlayTime { get; set; }
        public int? MasterClipStatusId { get; set; }
        public long? Idclip { get; set; }
        public int? StandByMasterPlaylistId { get; set; }
    }
}
