using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblRecordList
    {
        public long Idclip { get; set; }
        public int? RecordServerId { get; set; }
        public int? RouterInput { get; set; }
        public int? RecordStatus { get; set; }
        public int? FtpserverId { get; set; }
        public int? DeleteAfterCopy { get; set; }
        public int? IsAutoMode { get; set; }
        public string RecordFileName { get; set; }
    }
}
