using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TemplateItemViewModel
	{
		[Required]
		public Guid Id { get; set; }
		public Guid TemplateId { get; set; }
		[Display(Name = "Name", Prompt = "Name place")]
		public string Name { get; set; }
		[Display(Name = "Index", Prompt = "Index place")]
		public int Index { get; set; }

	}
}
