using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class ChannelCreateViewModel
	{
		[Required]
		[Display(Name = "Name", Prompt ="Name place")]
		public string Name { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
		[Display(Name = "Parent", Prompt ="Parent place")]
		public Guid? ParentId { get; set; }
	}
}
