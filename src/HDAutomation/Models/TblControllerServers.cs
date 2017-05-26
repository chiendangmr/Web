using System;
using System.Collections.Generic;

namespace HDAutomation.Models
{
    public partial class TblControllerServers
    {
        public int ControllerServerId { get; set; }
        public string ControllerServerName { get; set; }
        public string ControllerServerIpAddress { get; set; }
        public int? ImageId { get; set; }
        public string ControllerServerDescription { get; set; }
        public int? ControllerServerStatusId { get; set; }
        public bool? IsRedundancy { get; set; }
        public int? DomainId { get; set; }
        public int? WindowX { get; set; }
        public int? WindowY { get; set; }
    }
}
