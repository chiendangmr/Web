using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class ProductGroupDocumentRequest
    {
        public Guid ProductGroupId { get; set; }
        public Guid DocumentTypeId { get; set; }

        public virtual DocumentType DocumentType { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
    }
}
