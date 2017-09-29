using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ContentMetadataProfile
    {
        public ContentMetadataProfile()
        {
            ContentMetadataFieldset = new HashSet<ContentMetadataFieldset>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ContentMetadataFieldset> ContentMetadataFieldset { get; set; }
    }
}
