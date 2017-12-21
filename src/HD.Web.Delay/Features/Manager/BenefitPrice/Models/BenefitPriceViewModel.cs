using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class BenefitPriceViewModel
	{
		public Guid Id { get; set; }
		[Required]
		[Display(Name = "Type")]
		public Guid BenefitTypeId { get; set; }
		[Display(Name = "Type")]
		public string BenefitTypeCode { get; set; }
		[Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Required]
		[Display(Name = "Price")]
		[Range(0, int.MaxValue)]
		public decimal Price { get; set; }

		[Display(Name = "TimeBands")]
		public IEnumerable<Guid> TimeBandIds { get; set; }
		
		[Display(Name = "SponsorPrograms")]
		public IEnumerable<Guid> SponsorProgramIds { get; set; }
	}
}
