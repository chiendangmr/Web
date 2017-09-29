using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ContentMetadata
    {
        public Guid Id { get; set; }
        public Guid ContentMetadataInfoId { get; set; }
        public Guid? ContentMetadataValueId { get; set; }
        public string RawValue { get; set; }
        public Guid ContentId { get; set; }

        public virtual ContentMetadataInfo ContentMetadataInfo { get; set; }
        public virtual ContentMetadataValue ContentMetadataValue { get; set; }
    }
}
