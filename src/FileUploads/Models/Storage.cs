using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Storage
    {
        public Storage()
        {
            StorageLocation = new HashSet<StorageLocation>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StorageLocation> StorageLocation { get; set; }
    }
}
