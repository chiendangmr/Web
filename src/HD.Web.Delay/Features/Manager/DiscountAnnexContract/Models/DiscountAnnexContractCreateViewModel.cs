using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class DiscountAnnexContractCreateViewModel
	{
		[Display(Name = "AnnexContract")]
		public Guid AnnexContractId { get; set; }
		[Required]
		[Display(Name = "AnnexContract")]
		public string AnnexContractCode { get; set; }
		[Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Required]
		[Display(Name = "Rate", Prompt = "Rate place")]
		[Range(0,100)]
		public decimal Rate { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
		[Display(Name = "TimeBands")]
		public IEnumerable<Guid> TimeBandIds { get; set; }
	}
}
