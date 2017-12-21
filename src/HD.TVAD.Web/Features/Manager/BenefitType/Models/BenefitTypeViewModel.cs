using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class BenefitTypeViewModel
	{
		public Guid Id { get; set; }
		[Required]
		[Display(Name = "Code", Prompt = "Code place")]
		public string Code { get; set; }
		[Required]
		[Display(Name = "Name", Prompt = "Name place")]
		public string Name { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
	}
}
