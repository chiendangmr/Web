using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using HD.TVAD.ApplicationCore.Entities;

namespace HD.TVAD.Web.Models
{
    public class RetailContractForAPICreateViewModel
	{
		[Required]
		[Display(Name = "Customer")]
		public string CustomerName { get; set; }
		[Display(Name = "Address")]
		public string CustomerAddress { get; set; }
		[Display(Name = "Code")]
		public string Code { get; set; }
		[Display(Name = "Contract")]
		public Guid? ContractId { get; set; }
		[Required]
		[Display(Name = "BookingType")]
		public int BookingTypeId { get; set; }
		[Display(Name = "Annex Contract Type")]
		public Guid AnnexContractTypeId { get; set; }
		[Required]
		[Display(Name = "Receive Date")]
		public DateTime ReceiveDate { get; set; }
	}
}
