using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblUserGroup
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
        public int? GranterId { get; set; }
    }
}
