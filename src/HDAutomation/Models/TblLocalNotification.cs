using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblLocalNotification
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int ToUser { get; set; }
        public DateTime SendDate { get; set; }
        public string Content { get; set; }
        public bool Received { get; set; }
    }
}
