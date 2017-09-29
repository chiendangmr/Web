using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ContentMetadataType
    {
        public ContentMetadataType()
        {
            ContentMetadataInfo = new HashSet<ContentMetadataInfo>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HtmlTag { get; set; }

        public virtual ICollection<ContentMetadataInfo> ContentMetadataInfo { get; set; }
    }
}
