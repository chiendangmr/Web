using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SpotAssets
    {
        public Guid Id { get; set; }
        public Guid? SpotId { get; set; }
        public int Index { get; set; }

        public virtual SpotAssetByAssets SpotAssetByAssets { get; set; }
        public virtual SpotAssetByBookings SpotAssetByBookings { get; set; }
        public virtual Spots Spot { get; set; }
    }
}
