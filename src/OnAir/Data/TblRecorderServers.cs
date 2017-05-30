using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblRecorderServers
    {
        public int RecordServerId { get; set; }
        public string ChannelName { get; set; }
        public string ControlName { get; set; }
        public int? Color { get; set; }
        public int? Input { get; set; }
        public int? Output { get; set; }
        public int? Res { get; set; }
        public string ControlIpAddress { get; set; }
        public int? ControlPort { get; set; }
        public string ControlUserName { get; set; }
        public string ControlPassword { get; set; }
        public int? ServerId { get; set; }
        public int? RecorderServerStatus { get; set; }
        public int? ServerTypeId { get; set; }
    }
}
