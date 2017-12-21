using System;
using System.Collections.Generic;
using System.Linq;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Spot
    {
        public Spot()
        {
            SpotBookings = new HashSet<SpotBooking>();
			SpotAssets = new HashSet<SpotAsset>();
		}

        public Guid Id { get; set; }
        public DateTime BroadcastDate { get; set; }
        public Guid TimeBandSliceId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SpotBooking> SpotBookings { get; set; }
        public virtual TimeBandSlice TimeBandSlice { get; set; }
		public virtual ICollection<SpotAsset> SpotAssets { get; set; }
		public void ClearApproveBooking() {
			for (int i = SpotAssets.Count - 1; i >= 0; i--)
			{
				SpotAssets.Remove(SpotAssets.ElementAt(i));
			}
		}
		public void ApproveBooking(ICollection<SpotAsset> spotAssets)
		{
			for (int i = spotAssets.Count - 1; i >= 0; i--)
			{
				SpotAssets.Add(spotAssets.ElementAt(i));
			}
		}
		public bool HasBooking { get {
				return SpotAssets.Any(s => s.HasBooking);
			} }

		public bool HasAssetBooking
		{
			get
			{
				return SpotAssets.Any(s => s.HasAssetBooking);
			}
		}
		public string TimeBandName
		{
			get
			{
				return TimeBandSlice.TimeBand.TimeBandBase.Name;
			}
		}
		public Guid TimeBandId
		{
			get
			{
				return TimeBandSlice.TimeBand.TimeBandBase.Id;
			}
		}
		public string ChannelName
		{
			get
			{
				return TimeBandSlice.TimeBand.TimeBandBase.Parent.Name;
			}
		}
		public Guid ChannelId
		{
			get
			{
				return TimeBandSlice.TimeBand.TimeBandBase.Parent.Id;
			}
		}
		public string TimeBandSliceName
		{
			get
			{
				return TimeBandSlice.Name;
			}
		}


	}
}
