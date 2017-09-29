using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AssetDocumentFiles
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public Guid FileId { get; set; }
        public string Name { get; set; }

        public virtual AssetDocuments Document { get; set; }
        public virtual Files File { get; set; }
    }
}
