using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblPermissionGroup
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? PermissionId { get; set; }
    }
}
