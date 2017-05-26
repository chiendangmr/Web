using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblInfoAudio
    {
        public long Idclip { get; set; }
        public int AudioTrackId { get; set; }
        public string AudioTrackType { get; set; }
        public string AudioTrackLanguage { get; set; }
    }
}
