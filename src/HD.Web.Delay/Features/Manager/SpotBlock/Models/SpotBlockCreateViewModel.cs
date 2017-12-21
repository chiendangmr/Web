using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotBlockCreateViewModel
	{
	//	[Required(ErrorMessage = "This field is required")]
		[Display(Name = "Length", Prompt ="Duration place (second)")]
		[Range(1,300)]
		public int Length { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }

	}
}
