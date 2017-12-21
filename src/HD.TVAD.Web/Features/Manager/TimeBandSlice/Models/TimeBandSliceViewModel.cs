using HD.TVAD.ApplicationCore.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Name")]
		public string Name { get; set; }
		[Display(Name = "TimeBand")]
		public string TimeBandName { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }
		[Display(Name = "Max Duration")]
		public int MaxDuration { get; set; }
		[Display(Name = "Max Duration")]
		public Guid MaxDurationId { get; set; }

		public string NameForSort
		{
			get
			{
				return Util.GetValueToSort(Name);
			}
		}
	}
}
