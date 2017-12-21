using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotBlockRateEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public Guid SpotBlockId { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		[Required]
		public string Rate { get; set; }
		public string Description { get; set; }
	}
}
