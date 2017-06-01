using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblMonitorDevices
    {
        public int DeviceId { get; set; }
        public int? DeviceTypeId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceIpaddress { get; set; }
        public string ReadCommunityString { get; set; }
        public int DeviceStatus { get; set; }
        public bool? NotifiedStatus { get; set; }
        public byte[] DeviceAttribute { get; set; }
    }
}
