using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblMasterPlaylists
    {
        public int MasterPlaylistId { get; set; }
        public int SectorId { get; set; }
        public DateTime DateList { get; set; }
        public bool Islock { get; set; }
        public int? ApproverId { get; set; }
    }
}
