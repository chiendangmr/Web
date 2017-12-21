using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class AssetDocumentFile
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public Guid FileId { get; set; }
        public string Name { get; set; }

        public virtual AssetDocument Document { get; set; }
        public virtual File File { get; set; }
    }
}
