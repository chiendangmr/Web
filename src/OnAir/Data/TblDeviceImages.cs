using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblDeviceImages
    {
        public int ImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageDisplay { get; set; }
    }
}
