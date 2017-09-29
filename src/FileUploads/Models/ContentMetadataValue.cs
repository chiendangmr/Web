using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ContentMetadataValue
    {
        public ContentMetadataValue()
        {
            ContentMetadata = new HashSet<ContentMetadata>();
        }

        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public Guid ContentMetadataInfoId { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<ContentMetadata> ContentMetadata { get; set; }
        public virtual ContentMetadataInfo ContentMetadataInfo { get; set; }
        public virtual ContentMetadataValue Parent { get; set; }
        public virtual ICollection<ContentMetadataValue> InverseParent { get; set; }
    }
}
