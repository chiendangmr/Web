using HD.TVAD.ApplicationCore.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotBookingContractIndexViewModel
	{
		[Display(Name = "")]
		public Guid AnnexContractId { get; set; }
		public Guid Id { get; set; }
		public Guid CustomerId { get; set; }
		[Display(Name = "Customer")]
		public string CustomerName { get; set; }
		[Display(Name = "Code")]
		public string Code { get; set; }
		[Display(Name = "Contract")]
		public Guid? ContractId { get; set; }
		[Display(Name = "BookingType")]
		public BookingTypeEnum BookingTypeId { get; set; }
		[Display(Name = "Booking Type")]
		public string BookingTypeName { get; set; }
		[Display(Name = "Annex Contract Type")]
		public string AnnexContractTypeName { get; set; }
		[Display(Name = "Receive Date")]
		public DateTime ReceiveDate { get; set; }
		[Display(Name = "Sign Date")]
		public DateTime SignDate { get; set; }
		[Display(Name = "Campaign")]
		public string ScheduleCampaign { get; set; }
		[Display(Name = "Content")]
		public string Content { get; set; }
		[Display(Name = "Program")]
		public Guid? SponsorProgramId { get; set; }
		[Display(Name = "Program")]
		public string SponsorProgramName { get; set; }
		[Display(Name = "Sponsor Type")]
		public int? SponsorTypeId { get; set; }
		[Display(Name = "Sponsor Type")]
		public string SponsorTypeName { get; set; }
		public string IconBookingType { get; set; }


		[Display(Name = "Annex Contract Type")]
		public Guid? AnnexContractTypeId { get; set; }
	}
}
