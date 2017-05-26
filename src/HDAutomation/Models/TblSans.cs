using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblSans
    {
        public int SanId { get; set; }
        public string Sanname { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public long? TotalSize { get; set; }
        public long? RemainSize { get; set; }
        public string IpAddress1 { get; set; }
        public string IpAddress2 { get; set; }
        public int? NumberOfDisk { get; set; }
        public DateTime? AssembleDate { get; set; }
    }
}
