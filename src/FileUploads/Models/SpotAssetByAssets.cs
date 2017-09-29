using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SpotAssetByAssets
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }

        public virtual Content Asset { get; set; }
        public virtual SpotAssets IdNavigation { get; set; }
    }
}
