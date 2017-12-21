using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Name")]
		public string Name { get; set; }
		[Display(Name = "Parent")]
		public Guid? ParentId { get; set; }
		[Display(Name = "Channel")]
		public Guid ChannelId { get; set; }
		[Display(Name = "Channel")]
		public String ChannelName { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }
		[Display(Name = "Description by Day")]
		public string TimeBandDescription { get; set; }
		[Display(Name = "Day Of Week")]
		public int DayOfWeeks { get; set; }
		[Display(Name = "Start Time Of Day")]
		public TimeSpan StartTimeOfDay { get; set; }
		[Display(Name = "Duration")]
		public int Duration { get; set; }

		[Display(Name = "Next Day")]
		public string NextDay { get; set; }
		[Display(Name = "End Time")]
		public TimeSpan EndTime { get; set; }

		public TimeBandDayViewModel TimeBandDay { get; set; }


		public string NameForSort
		{
			get
			{
				return Util.GetValueToSort(Name);
			}
		}
	}
}
