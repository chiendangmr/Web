using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SpotAsset
    {
        public Guid Id { get; set; }
        public Guid? SpotId { get; set; }
        public int Index { get; set; }

        public virtual SpotAssetByAsset SpotAssetByAssets { get; set; }
        public virtual SpotAssetByBooking SpotAssetByBookings { get; set; }
        public virtual Spot Spot { get; set; }

		public bool HasBooking
		{
			get
			{
				return SpotAssetByBookings != null;
			}
		}
		public bool HasAssetBooking
		{
			get
			{
				return SpotAssetByAssets != null;
			}
		}
	}
}
