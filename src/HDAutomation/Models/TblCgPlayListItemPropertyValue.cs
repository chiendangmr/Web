using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblCgPlaylistItemPropertyValue
    {
        public long Id { get; set; }
        public long CgItemId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
