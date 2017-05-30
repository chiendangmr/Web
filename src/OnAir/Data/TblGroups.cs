using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblGroups
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string AllowSectorList { get; set; }
    }
}
