using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AssetDocuments
    {
        public AssetDocuments()
        {
            AssetDocumentFiles = new HashSet<AssetDocumentFiles>();
            AssetDocumentLinksDocument = new HashSet<AssetDocumentLinks>();
            AssetDocumentLinksOriginDocument = new HashSet<AssetDocumentLinks>();
        }

        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public Guid TypeId { get; set; }
        public int? Approve { get; set; }
        public string ApproveNote { get; set; }

        public virtual ICollection<AssetDocumentFiles> AssetDocumentFiles { get; set; }
        public virtual ICollection<AssetDocumentLinks> AssetDocumentLinksDocument { get; set; }
        public virtual ICollection<AssetDocumentLinks> AssetDocumentLinksOriginDocument { get; set; }
        public virtual Content Asset { get; set; }
        public virtual DocumentTypes Type { get; set; }
    }
}
