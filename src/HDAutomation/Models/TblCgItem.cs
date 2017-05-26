using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblCgItem
    {
        public long Id { get; set; }
        public int Transparent { get; set; }
        public int XStart { get; set; }
        public int YStart { get; set; }
        public int XEnd { get; set; }
        public int YEnd { get; set; }
        public int XSpeed { get; set; }
        public int YSpeed { get; set; }
        public int Repeat { get; set; }
        public string RepeatDelay { get; set; }
        public int? FadeInTime { get; set; }
        public int? FadeOutTime { get; set; }
        public int? RotateStart { get; set; }
        public int? RotateEnd { get; set; }
        public int? RotateSpeed { get; set; }
        public double? ScaleStart { get; set; }
        public double? ScaleEnd { get; set; }
        public double? ScaleSpeed { get; set; }
        public long? Cgcounter { get; set; }
        public long? Cgvideo { get; set; }
        public long? Cgimage { get; set; }
        public long? Cgtext { get; set; }
        public int? Cgtemplate { get; set; }
    }
}
