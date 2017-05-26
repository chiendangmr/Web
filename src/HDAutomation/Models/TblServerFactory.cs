using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblServerFactory
    {
        public int ServerFactoryId { get; set; }
        public string ServerFactoryName { get; set; }
        public string GetSizeUserName { get; set; }
        public string GetSizePassword { get; set; }
        public string GetSizeDirectory { get; set; }
        public string GetSizeExtension { get; set; }
        public double? GetSizeFactor { get; set; }
    }
}
