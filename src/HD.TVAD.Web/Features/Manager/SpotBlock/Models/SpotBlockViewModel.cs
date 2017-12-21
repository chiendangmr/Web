using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.Web.Models
{
    public class SpotBlockViewModel
	{
		public Guid Id { get; set; }
		[Required(), Display(Name = "Length")]
		public int Length { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }

	}
}
