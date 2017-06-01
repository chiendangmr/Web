using System;
using System.Collections.Generic;

namespace HDAutomationWebAPI.Models
{
    public partial class TblCgPlaylistItemPropertyValue
    {
        public long Id { get; set; }
        public long CgItemId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
