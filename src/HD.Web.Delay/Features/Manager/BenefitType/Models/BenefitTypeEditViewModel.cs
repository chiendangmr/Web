using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
	public class BenefitTypeEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
	//	[Required]
		[Display(Name = "Code")]
		public string Code { get; set; }
		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }
	}
}
