using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblMonitorDeviceTypeAttribute
    {
        public int Id { get; set; }
        public int? DeviceTypeId { get; set; }
        public int? AttributeId { get; set; }
        public string IdToGetInfo { get; set; }
        public double? WarningThreadholdValue { get; set; }
        public double? ErrorThreadHoldValue { get; set; }
        public byte[] AttributeData { get; set; }
    }
}
