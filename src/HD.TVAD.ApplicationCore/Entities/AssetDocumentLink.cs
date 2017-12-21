using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class AssetDocumentLink
    {
        public Guid OriginDocumentId { get; set; }
        public Guid DocumentId { get; set; }

        public virtual AssetDocument Document { get; set; }
        public virtual AssetDocument OriginDocument { get; set; }
    }
}
