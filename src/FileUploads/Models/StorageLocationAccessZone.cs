using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class StorageLocationAccessZone
    {
        public Guid Id { get; set; }
        public Guid StorageLocationAccessId { get; set; }
        public Guid AccessZoneId { get; set; }

        public virtual AcessZone AccessZone { get; set; }
        public virtual StorageLocationAccess StorageLocationAccess { get; set; }
    }
}
