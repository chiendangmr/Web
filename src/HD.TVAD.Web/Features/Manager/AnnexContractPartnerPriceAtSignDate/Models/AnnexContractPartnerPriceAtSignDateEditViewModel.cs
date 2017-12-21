using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class AnnexContractPartnerPriceAtSignDateEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		[Display(Name = "Annex Contract")]
		public Guid AnnexContractId { get; set; }
		[Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }

	}
}
