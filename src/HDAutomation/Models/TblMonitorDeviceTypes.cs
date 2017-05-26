using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblMonitorDeviceTypes
    {
        public int DeviceTypeId { get; set; }
        public string DeviceTypeDescription { get; set; }
        public string OkimageUrl { get; set; }
        public string WarningImageUrl { get; set; }
        public string ErrorImageUrl { get; set; }
        public byte[] NormalImg { get; set; }
        public byte[] WarningImg { get; set; }
        public byte[] ErrorImg { get; set; }
    }
}
