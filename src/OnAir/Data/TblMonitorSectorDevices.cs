using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblMonitorSectorDevices
    {
        public int Id { get; set; }
        public int? SectorId { get; set; }
        public int? DeviceId { get; set; }
        public int? PosX { get; set; }
        public int? PosY { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public byte[] Label { get; set; }
    }
}
