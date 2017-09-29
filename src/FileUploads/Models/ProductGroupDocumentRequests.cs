using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ProductGroupDocumentRequests
    {
        public Guid ProductGroupId { get; set; }
        public Guid DocumentTypeId { get; set; }

        public virtual DocumentTypes DocumentType { get; set; }
        public virtual ProductGroups ProductGroup { get; set; }
    }
}
