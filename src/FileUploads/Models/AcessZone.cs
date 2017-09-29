using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AcessZone
    {
        public AcessZone()
        {
            StorageLocationAccessZone = new HashSet<StorageLocationAccessZone>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StorageLocationAccessZone> StorageLocationAccessZone { get; set; }
    }
}
