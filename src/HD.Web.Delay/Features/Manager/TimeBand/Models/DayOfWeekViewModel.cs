using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class DayOfWeekViewModel
	{
		[Display(Name = "Monday")]
		public bool Monday { get; set; }
		[Display(Name = "Tuesday")]
		public bool Tuesday { get; set; }
		[Display(Name = "Wednesday")]
		public bool Wednesday { get; set; }
		[Display(Name = "Thursday")]
		public bool Thursday { get; set; }
		[Display(Name = "Friday")]
		public bool Friday { get; set; }
		[Display(Name = "Saturday")]
		public bool Saturday { get; set; }
		[Display(Name = "Sunday")]
		public bool Sunday { get; set; }
	}
}
