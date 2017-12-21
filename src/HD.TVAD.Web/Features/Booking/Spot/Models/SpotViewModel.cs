using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotViewModel
	{
		public Guid Id { get; set; }
		public Guid SpotId { get; set; }
		public Guid SpotBookingId { get; set; }
		public Guid AnnexContractAssetId { get; set; }
		
		public DateTime BroadcastDate { get; set; }
		public Guid TimeBandId { get; set; }
		public string TimeBandName { get; set; }
		public string TimebandNameToSort { get; set; }
		public string TimeBandDescription { get; set; }
		public Guid? TimeBandSliceId { get; set; }
		public string TimeBandSliceName { get; set; }
		public string TimeBandSliceDescription { get; set; }

		public bool? PositionCost { get; set; }


		public Guid AssetId { get; set; }
		public string AssetCode { get; set; }
		public string ProductName { get; set; }
		public int AssetBlockDuration { get; set; }

		public int? Position { get; set; }
		public int? TmpOrder { get; set; }
		public int? Index { get; set; }
		public bool? ApproveOnAir { get; set; }

		public int BookingAssetType { get; set; }
		public int MaxDuration { get; set; }


		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }
		public string ContractCode { get; set; }
		public int BookingTypeId { get; set; }
		public string BookingTypeName { get; set; }
		public string SponsorProgramName { get; set; }
		public Guid? SponsorProgramId { get; set; }


		public string ChannelName { get; set; }
		public Guid ChannelId { get; set; }
	}
}
