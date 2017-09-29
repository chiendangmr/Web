using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class ProductGroups
    {
        public ProductGroups()
        {
            Content = new HashSet<Content>();
            ProductGroupDocumentRequests = new HashSet<ProductGroupDocumentRequests>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<Content> Content { get; set; }
        public virtual ICollection<ProductGroupDocumentRequests> ProductGroupDocumentRequests { get; set; }
        public virtual ProductGroups Parent { get; set; }
        public virtual ICollection<ProductGroups> InverseParent { get; set; }
    }
}
