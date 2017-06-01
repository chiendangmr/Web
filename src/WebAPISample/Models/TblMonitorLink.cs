using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblMonitorLink
    {
        public int Id { get; set; }
        public int SrcDeviceId { get; set; }
        public int DestDeviceId { get; set; }
        public int SrcPort { get; set; }
        public int DestPort { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public byte[] Data { get; set; }
    }
}
