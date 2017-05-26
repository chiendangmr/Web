using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblMonitorSectors
    {
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string ThumbnailImageUrlOk { get; set; }
        public string ThumbnailImageUrlWarning { get; set; }
        public string ThumbnailImageUrlError { get; set; }
        public byte[] ThumbnailNormal { get; set; }
        public byte[] ThumbnailWarning { get; set; }
        public byte[] ThumbnailError { get; set; }
        public bool Visible { get; set; }
    }
}
