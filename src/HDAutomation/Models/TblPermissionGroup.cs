using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblPermissionGroup
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? PermissionId { get; set; }
    }
}
