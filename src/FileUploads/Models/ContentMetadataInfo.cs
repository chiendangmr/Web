using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ContentMetadataInfo
    {
        public ContentMetadataInfo()
        {
            ContentMetadata = new HashSet<ContentMetadata>();
            ContentMetadataProfileField = new HashSet<ContentMetadataProfileField>();
            ContentMetadataValue = new HashSet<ContentMetadataValue>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Prompt { get; set; }
        public string Description { get; set; }
        public Guid ContentMetadataTypeId { get; set; }
        public string DefaultValue { get; set; }
        public string TagAttributes { get; set; }
        public bool Disabled { get; set; }
        public string SqlValueOption { get; set; }
        public string SqlValueSet { get; set; }
        public string EnumType { get; set; }
        public bool IsContentField { get; set; }
        public string PartialName { get; set; }

        public virtual ICollection<ContentMetadata> ContentMetadata { get; set; }
        public virtual ICollection<ContentMetadataProfileField> ContentMetadataProfileField { get; set; }
        public virtual ICollection<ContentMetadataValue> ContentMetadataValue { get; set; }
        public virtual ContentMetadataType ContentMetadataType { get; set; }
    }
}
