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
    public class AnnexContractCreateViewModel
	{
		
		[Required]
		public Guid CustomerId { get; set; }
	//	[Required]
		public string Code { get; set; }
		public Guid? ContractId { get; set; }
		[Required]
		public BookingTypeEnum BookingTypeId { get; set; }		
		public Guid? AnnexContractTypeId { get; set; }
		[Required]
		public DateTime ReceiveDate { get; set; }
		[Required]
		public DateTime SignDate { get; set; }
		public string ScheduleCampaign { get; set; }
		public string Content { get; set; }
		public Guid? SponsorProgramId { get; set; }
		public string SponsorProgramName { get; set; }
		public int? SponsorTypeId { get; set; }
		public string SponsorTypeName { get; set; }
	}
}
