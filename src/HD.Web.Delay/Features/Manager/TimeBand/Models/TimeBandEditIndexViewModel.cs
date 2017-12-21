using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandEditIndexViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid ChannelId { get; set; }
		public String ChannelName { get; set; }
		public DateTimeOffset? StartTime { get; set; }
		public DateTimeOffset? EndTime { get; set; }
		public Guid? OnDayId { get; set; }
		public Guid? OnDayName { get; set; }
		public string Description { get; set; }
		public Guid? DayPartId { get; set; }
		public string DayPartName { get; set; }
	}
}
