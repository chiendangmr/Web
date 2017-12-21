using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TemplateItemCreateViewModel
	{
		[Required]
		public Guid TemplateId { get; set; }
		[Required]
		[Display(Name = "Name", Prompt = "Name place")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "Index", Prompt = "Index place")]
		public int Index { get; set; }
	}
}
