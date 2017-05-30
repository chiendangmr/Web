using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblServers
    {
        public int ServerId { get; set; }
        public string ServerName { get; set; }
        public int? StorageId { get; set; }
        public int? FtpServerId { get; set; }
        public int? ReferenceInput { get; set; }
        public int? ReferenceOutput { get; set; }
        public int? ImageId { get; set; }
        public bool? IsRedundancy { get; set; }
        public int? DomainId { get; set; }
        public int? ServerStatusId { get; set; }
        public int? ServerFactoryId { get; set; }
    }
}
