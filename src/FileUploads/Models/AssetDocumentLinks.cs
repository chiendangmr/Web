using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AssetDocumentLinks
    {
        public Guid OriginDocumentId { get; set; }
        public Guid DocumentId { get; set; }

        public virtual AssetDocuments Document { get; set; }
        public virtual AssetDocuments OriginDocument { get; set; }
    }
}
