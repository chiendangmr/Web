using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TempPlayListItem
    {
        public long Id { get; set; }
        public int? ListId { get; set; }
        public long? Idclip { get; set; }
        public int? OrderClip { get; set; }
        public string PlayTcIn { get; set; }
        public string PlayTcOut { get; set; }
        public string Command { get; set; }
        public string Command1 { get; set; }
        public string Note { get; set; }
        public int? Setting { get; set; }
    }
}
