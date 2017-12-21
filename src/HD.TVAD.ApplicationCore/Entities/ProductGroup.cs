using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Assets = new HashSet<Content>();
            ProductGroupDocumentRequests = new HashSet<ProductGroupDocumentRequest>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<Content> Assets { get; set; }
        public virtual ICollection<ProductGroupDocumentRequest> ProductGroupDocumentRequests { get; set; }
        public virtual ProductGroup Parent { get; set; }
        public virtual ICollection<ProductGroup> InverseParent { get; set; }
    }
}
