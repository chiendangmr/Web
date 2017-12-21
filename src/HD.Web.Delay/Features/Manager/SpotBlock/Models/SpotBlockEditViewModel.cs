using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.Web.Models
{
    public class SpotBlockEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required(ErrorMessage = "This field is required")]
		[Display(Name = "Length", Prompt = "Duration place")]
		public int Length { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }

	}
}
