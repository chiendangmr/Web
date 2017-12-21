using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            AssetDocuments = new HashSet<AssetDocument>();
            ProductGroupDocumentRequests = new HashSet<ProductGroupDocumentRequest>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<AssetDocument> AssetDocuments { get; set; }
        public virtual ICollection<ProductGroupDocumentRequest> ProductGroupDocumentRequests { get; set; }
        public virtual DocumentType Parent { get; set; }
        public virtual ICollection<DocumentType> InverseParent { get; set; }
    }
}
