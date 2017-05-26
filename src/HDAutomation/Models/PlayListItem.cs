using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class PlayListItem
    {
        public long Id { get; set; }
        public int ListId { get; set; }
        public long Idclip { get; set; }
        public long? IdclipSubstitute { get; set; }
        public int OrderClip { get; set; }
        public string PlayTcIn { get; set; }
        public string PlayTcOut { get; set; }
        public string Command { get; set; }
        public string Command1 { get; set; }
        public string Note { get; set; }
        public int Setting { get; set; }
        public string StartTime { get; set; }
        public string ColorDisplay { get; set; }
        public int? Status { get; set; }
        public int? RouterInput { get; set; }
        public string CommandAtEnd { get; set; }
        public int? StandbyPlaylistId { get; set; }
        public long? MasterPlaylistItemId { get; set; }
        public int? VtrId { get; set; }
        public int? Changed { get; set; }
        public long? ClusterId { get; set; }
        public string PlayTime { get; set; }
        public int EventType { get; set; }
        public bool? Approved { get; set; }
        public string RealPlayTcIn { get; set; }
        public string RealPlayTcOut { get; set; }
        public Guid SyncId { get; set; }
        public string RowColor { get; set; }
        public string ProgramNote { get; set; }
    }
}
