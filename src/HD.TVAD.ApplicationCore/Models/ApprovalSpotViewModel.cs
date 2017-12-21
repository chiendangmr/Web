using System;

namespace HD.TVAD.ApplicationCore.Models
{
	public class ApprovalSpotViewModel
	{
		public Guid Id { get; set; }
		public int? Position { get; set; }
		public int? TmpOrder { get; set; }
		public bool? PositionCost { get; set; }


		public Guid? BroadcastId { get; set; }
		public int BroadcastIndex { get; set; }

		public Guid AnnexContractId { get; set; }
		public string AnnexContractCode { get; set; }
		public int BookingTypeId { get; set; }

		public Guid ContentId { get; set; }
		public string Code { get; set; }
		public string ProductName { get; set; }
		public int BlockDuration { get; set; }


		public Guid SpotId { get; set; }
		public string SpotDescription { get; set; }

		public Guid SliceId { get; set; }
		public string SliceName { get; set; }
		public string SliceDescription { get; set; }
		public int SliceDuration { get; set; }


		public Guid TimebandId { get; set; }
		public string TimebandName { get; set; }
		public string TimebandNameToSort { get; set; }
		public string TimebandDescription { get; set; }

		public Guid ChannelId { get; set; }
		public string ChannelName { get; set; }
		public string ChannelDescription { get; set; }

		public DateTime BroadcastDate { get; set; }
		public int Type { get; set; }



	}
}