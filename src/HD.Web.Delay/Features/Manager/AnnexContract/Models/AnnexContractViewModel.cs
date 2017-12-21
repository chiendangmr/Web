using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Booking;

namespace HD.TVAD.Web.Models
{
    public class AnnexContractViewModel
	{
		
		public Guid Id { get; set; }
		[Display(Name = "Customer")]
		[Required]
		public Guid CustomerId { get; set; }
		[Display(Name = "Customer Name")]
		public string CustomerName { get; set; }
		[Display(Name = "Code", Prompt ="Code place")]
	//	[Required]
		public string Code { get; set; }
		[Display(Name = "Contract")]
		public Guid? ContractId { get; set; }
		[Display(Name = "Booking Type")]
		[Required]
		public BookingTypeEnum BookingTypeId { get; set; }
		[Display(Name = "Booking Type Name")]
		public string BookingTypeName { get; set; }

		[Display(Name = "Annex Contract Type")]
		public Guid? AnnexContractTypeId { get; set; }
		[Display(Name = "Annex Contract Type Name")]
		public string AnnexContractTypeName { get; set; }
		[Required]
		[Display(Name = "Receive Date")]
		public DateTime ReceiveDate { get; set; }

		[Required]
		[Display(Name = "Sign Date")]
		public DateTime SignDate { get; set; }
		[Display(Name = "Schedule Campaign", Prompt = "Schedule Campaign place")]
		public string ScheduleCampaign { get; set; }
		[Display(Name = "Content", Prompt ="Content place")]
		public string Content { get; set; }
		[Display(Name = "Sponsor Program")]
		public Guid? SponsorProgramId { get; set; }
		[Display(Name = "Sponsor Program")]
		public string SponsorProgramName { get; set; }
		[Display(Name = "Sponsor Type")]
		public int? SponsorTypeId { get; set; }
		[Display(Name = "Sponsor Type")]
		public string SponsorTypeName { get; set; }
	}
}
