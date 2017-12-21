using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class PositionRateViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "TimeBand")]
		public Guid? TimeBandId { get; set; }
		[Display(Name = "TimeBand Name")]
		public string TimeBandName { get; set; }
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		[DataType(DataType.Date)]
	//	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime? EndDate { get; set; }
		[Display(Name = "Rate", Prompt = "Rate place")]
		[Range(0, 100)]
		public decimal Rate { get; set; }
	}
}
