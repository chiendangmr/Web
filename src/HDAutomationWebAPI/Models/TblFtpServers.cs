using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblFtpServers
    {
        public int FtpServerId { get; set; }
        public string FtpServerName { get; set; }
        public string FtpUserName { get; set; }
        public string FtpPassword { get; set; }
        public string FtpDataDirectory { get; set; }
        public int? FtpPort { get; set; }
        public string FtpIpAddress { get; set; }
        public long? TotalSize { get; set; }
        public long? RemainSize { get; set; }
        public int? CanNotEdit { get; set; }
    }
}
