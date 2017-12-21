using HD.TVAD.ApplicationCore.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class AnnexContractAssetForNormalBookingCreateViewModel
	{
		public Guid Id { get; set; }
		[Required]
		public Guid AnnexContractId { get; set; }
		[Display(Name = "Asset")]
		public Guid AssetId { get; set; }
		[Display(Name = "Price Type")]
		[Required]
		public Guid PriceTypeDetailId { get; set; }

		[Display(Name = "Asset")]
		[Required]
		public string AssetCode { get; set; }
		[Display(Name = "Product")]
		public string AssetProductName { get; set; }
		public int AssetBlockDuration { get; set; }


		[Display(Name = "Content", Prompt = "Content place")]
		public string Content { get; set; }
		[Display(Name = "Price", Prompt = "Price place")]
		public decimal? Price { get; set; }

		public BookingTypeEnum BookingType { get; set; }
	}
}
