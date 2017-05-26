using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblRouterConnections
    {
        public int ConnectionId { get; set; }
        public int? RouterId { get; set; }
        public int? PortOutput { get; set; }
        public int? PortInput { get; set; }
    }
}
