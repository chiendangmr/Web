using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class DocumentTypes
    {
        public DocumentTypes()
        {
            AssetDocuments = new HashSet<AssetDocuments>();
            ProductGroupDocumentRequests = new HashSet<ProductGroupDocumentRequests>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<AssetDocuments> AssetDocuments { get; set; }
        public virtual ICollection<ProductGroupDocumentRequests> ProductGroupDocumentRequests { get; set; }
        public virtual DocumentTypes Parent { get; set; }
        public virtual ICollection<DocumentTypes> InverseParent { get; set; }
    }
}
