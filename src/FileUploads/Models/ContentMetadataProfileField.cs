using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ContentMetadataProfileField
    {
        public Guid Id { get; set; }
        public Guid ContentMetadataInfoId { get; set; }
        public Guid ContentMetadataFieldsetId { get; set; }
        public int OrderNumber { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public bool Editable { get; set; }
        public bool Searchable { get; set; }
        public bool Sortable { get; set; }

        public virtual ContentMetadataFieldset ContentMetadataFieldset { get; set; }
        public virtual ContentMetadataInfo ContentMetadataInfo { get; set; }
    }
}
