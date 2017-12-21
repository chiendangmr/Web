using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class DiscountAnnexContractEditViewModel
	{
		public Guid Id { get; set; }
		[Required]
		[Display(Name = "AnnexContract")]
		public Guid AnnexContractId { get; set; }
		[Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Required]
		[Display(Name = "Rate", Prompt = "Rate place")]
		public string Rate { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
		[Display(Name = "TimeBands")]
		public IEnumerable<Guid> TimeBandIds { get; set; }
	}
}
