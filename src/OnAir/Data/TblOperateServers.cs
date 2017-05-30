using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblOperateServers
    {
        public TblOperateServers()
        {
            V4branch = new HashSet<V4branch>();
        }

        public int OperateServerId { get; set; }
        public string OperateServerName { get; set; }
        public string ControlName { get; set; }
        public int? Color { get; set; }
        public int? Input { get; set; }
        public int? Output { get; set; }
        public int? ResolutionSupport { get; set; }
        public string ControlIpAddress { get; set; }
        public int? ControlPort { get; set; }
        public string ControlUserName { get; set; }
        public string ControlPassword { get; set; }
        public int? ServerId { get; set; }
        public int? OperateServerStatus { get; set; }
        public int? ServerTypeId { get; set; }
        public int? OperateMode { get; set; }
        public int? ServerDeviceTypeId { get; set; }
        public int? GroupId { get; set; }
        public int? WindowX { get; set; }
        public int? WindowY { get; set; }
        public string FileExtensionOnServerForControl { get; set; }
        public bool? MustIncludeExtensionWhenControl { get; set; }
        public string NativeIp { get; set; }
        public string NativePath { get; set; }
        public string NativeProtocol { get; set; }
        public string NativeUserName { get; set; }
        public string NativePassword { get; set; }
        public string NativeDomain { get; set; }
        public string NativePort { get; set; }

        public virtual ICollection<V4branch> V4branch { get; set; }
    }
}
