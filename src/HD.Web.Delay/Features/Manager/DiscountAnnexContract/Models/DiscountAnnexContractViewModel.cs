using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class DiscountAnnexContractViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "AnnexContract")]
		public Guid AnnexContractId { get; set; }
		[Display(Name = "AnnexContract Code")]
		public string AnnexContractCode { get; set; }
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Display(Name = "Rate", Prompt = "Rate place")]
		[Range(0, 100)]
		public decimal Rate { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
		[Display(Name = "TimeBands")]
		public IEnumerable<Guid> TimeBandIds { get; set; }
	}
}
