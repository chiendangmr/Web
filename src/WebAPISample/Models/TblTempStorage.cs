using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblTempStorage
    {
        public long Idclip { get; set; }
        public string HostIp { get; set; }
        public string FilePath { get; set; }
        public string VideoPath { get; set; }
        public string LowResPath { get; set; }
        public string Audio1Path { get; set; }
        public string Audio2Path { get; set; }
        public string Audio3Path { get; set; }
        public string Audio4Path { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string NewWavfile { get; set; }
        public string NewSubtitleFile { get; set; }
    }
}
