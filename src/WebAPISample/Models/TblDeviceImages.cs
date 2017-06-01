using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblDeviceImages
    {
        public int ImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageDisplay { get; set; }
    }
}
