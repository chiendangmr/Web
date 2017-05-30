using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblMonitorDeviceLogs
    {
        public long Id { get; set; }
        public int? DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceIpaddress { get; set; }
        public string LogMessage { get; set; }
        public DateTime? LogTime { get; set; }
        public int? LogDeviceStatus { get; set; }
    }
}
