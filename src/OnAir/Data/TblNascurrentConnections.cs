using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblNascurrentConnections
    {
        public Guid Id { get; set; }
        public int? NasId { get; set; }
        public string ClientIp { get; set; }
        public DateTime? StartTime { get; set; }
        public long? Speed { get; set; }
        public long? DataSize { get; set; }
    }
}
