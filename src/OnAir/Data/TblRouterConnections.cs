using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblRouterConnections
    {
        public int ConnectionId { get; set; }
        public int? RouterId { get; set; }
        public int? PortOutput { get; set; }
        public int? PortInput { get; set; }
    }
}
