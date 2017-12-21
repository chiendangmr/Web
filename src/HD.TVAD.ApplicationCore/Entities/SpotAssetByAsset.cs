using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SpotAssetByAsset
    {
        public Guid Id { get; set; }
		public Guid AssetId { get; set; }
		public int? TmpOrder { get; set; }

		public virtual Content Asset { get; set; }
        public virtual SpotAsset SpotAsset { get; set; }
    }
}
