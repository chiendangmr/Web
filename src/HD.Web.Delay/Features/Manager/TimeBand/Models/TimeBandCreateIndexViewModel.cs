using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandCreateIndexViewModel
	{
		[Required]
		[Display(Name = "Name",Prompt ="Name place")]
		public string Name { get; set; }
		[Display(Name = "Description", Prompt ="Description place")]
		public string Description { get; set; }
		[Display(Name = "Channel", Prompt = "Channel place")]
		[Required]
		public Guid ChannelId { get; set; }
		[Display(Name = "Parent", Prompt ="Parent place")]
		public Guid? ParentId { get; set; }
		[Required]
		public TimeBandDescriptionViewModel TimeBandDescription { get; set; }
		[Required]
		[Display(Name = "TimeBand Day", Prompt = "TimeBand Day place")]
		public TimeBandDayViewModel TimeBandDay { get; set; }
		[Required]
		public TimeBandTimeViewModel TimeBandTime { get; set; }

	}
}
