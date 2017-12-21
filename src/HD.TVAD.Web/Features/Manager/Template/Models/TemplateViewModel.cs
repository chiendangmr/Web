using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TemplateViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Name", Prompt = "Name place")]
		public string Name { get; set; }

	}
}
