using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblDeviceImages
    {
        public int ImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageDisplay { get; set; }
    }
}
