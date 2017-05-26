using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class PlayListHistory
    {
        public long Id { get; set; }
        public string SectorName { get; set; }
        public DateTime DateList { get; set; }
        public DateTime LastTime { get; set; }
        public string UserName { get; set; }
        public string Value { get; set; }
    }
}
