using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblIngestUsingResource
    {
        public long Id { get; set; }
        public int? RecordAppId { get; set; }
        public int? SourceServerId { get; set; }
        public int? DestServerId { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
