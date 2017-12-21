using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class AssetDocument
    {
        public AssetDocument()
        {
            AssetDocumentFiles = new HashSet<AssetDocumentFile>();
            AssetDocumentLinksDocument = new HashSet<AssetDocumentLink>();
            AssetDocumentLinksOriginDocument = new HashSet<AssetDocumentLink>();
        }

        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public Guid TypeId { get; set; }
        public int? Approve { get; set; }
        public string ApproveNote { get; set; }

        public virtual ICollection<AssetDocumentFile> AssetDocumentFiles { get; set; }
        public virtual ICollection<AssetDocumentLink> AssetDocumentLinksDocument { get; set; }
        public virtual ICollection<AssetDocumentLink> AssetDocumentLinksOriginDocument { get; set; }
        public virtual Content Asset { get; set; }
        public virtual DocumentType Type { get; set; }
    }
}
