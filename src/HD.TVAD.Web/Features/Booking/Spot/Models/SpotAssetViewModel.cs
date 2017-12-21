using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotAssetViewModel
    {
		public Guid Id { get; set; }
		[Display(Name = "Spot")]
		public Guid SpotId { get; set; }
		[Display(Name = "Asset")]
		public Guid AssetId { get; set; }
		[Display(Name = "Index")]
		public int Index { get; set; }
		[Display(Name = "PositionCost")]
		public bool PositionCost { get; set; }
		public bool IsApproved { get; set; }
		public int TmpOrder { get; set; }

		[Display(Name = "Type")]
		public int BookingAssetType { get; set; }

		[Display(Name = "Asset Code", Prompt = "Asset Code place")]
		public string AssetCodeDisplay { get; set; }
	}
}
