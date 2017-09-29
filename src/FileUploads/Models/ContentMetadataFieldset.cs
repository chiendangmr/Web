using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ContentMetadataFieldset
    {
        public ContentMetadataFieldset()
        {
            ContentMetadataProfileField = new HashSet<ContentMetadataProfileField>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ContentMetadataProfileId { get; set; }
        public string PartialName { get; set; }

        public virtual ICollection<ContentMetadataProfileField> ContentMetadataProfileField { get; set; }
        public virtual ContentMetadataProfile ContentMetadataProfile { get; set; }
    }
}
