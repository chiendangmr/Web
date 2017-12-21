using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBands
{
    public static class MappingExtension
	{
		public static TimeBandViewModel ToViewModel(this TimeBand item)
		{
			var timeBandDescription = item.TimeBandDescriptions
				.Where(t => t.StartDate <= DateTime.Today)
				.OrderByDescending(t => t.StartDate)
				.FirstOrDefault();
			var description = timeBandDescription != null? timeBandDescription.Description :"";


			var dayOfWeeks = item.TimeBandDays
				.Where(t => t.StartDate <= DateTime.Today)
				.OrderByDescending(t => t.StartDate)
				.FirstOrDefault();
			var dayOfWeek = dayOfWeeks != null ? dayOfWeeks.DayOfWeeks : 0;

			var timeBandTime = item.TimeBandTimes
				.Where(t => t.StartDate <= DateTime.Today)
				.OrderByDescending(t => t.StartDate)
				.FirstOrDefault();
			var startTime = timeBandTime != null ? timeBandTime.StartTimeOfDay : new TimeSpan(0);
			
			var duration = timeBandTime != null ? timeBandTime.Duration : 0;

			return new TimeBandViewModel()
			{
				Id = item.Id,
				ChannelId = item.TimeBandBase.Parent.Id,
				ChannelName = item.TimeBandBase.Parent.Name,
				Name = item.TimeBandBase.Name,
				Description = item.TimeBandBase.Description,
				ParentId = item.TimeBandBase.ParentId,
				TimeBandDescription = description,
				DayOfWeeks = dayOfWeek,
				StartTimeOfDay = startTime,
				Duration = duration,			
			};
		}

		public static TimeBandEditViewModel ToEditViewModel(this TimeBand item)
		{
			return new TimeBandEditViewModel()
			{
				Id = item.Id,
				Name = item.TimeBandBase.Name,
				Description = item.TimeBandBase.Description,
				ChannelId = item.TimeBandBase.ParentId.Value,
				ParentId = item.TimeBandBase.ParentId.Value,
			};
		}
		public static IEnumerable<TimeBandViewModel> ToViewModel(this IQueryable<TimeBand> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBand ToDataModel(this TimeBandCreateIndexViewModel viewModel)
		{
			var today = DateTime.Today;
			var timeBandId = Guid.NewGuid();
			var timebandDescription = viewModel.TimeBandDescription;
			var timebandDay = viewModel.TimeBandDay;
			var timebandTime = viewModel.TimeBandTime;
			var dayOfWeeks = viewModel.TimeBandDay.DayOfWeekView;
			var dayOfWeekInt = TimeBandUtil.ConvertDayOfWeekViewToSumInt(dayOfWeeks);

			var timeBand = new TimeBand()
			{
				Id = timeBandId,
				TimeBandBase = new TimeBandBase()
				{
					Id = timeBandId,
					Name = viewModel.Name,
					ParentId = viewModel.ParentId,
					Description = viewModel.Description
				}
			};
			timeBand.TimeBandDescriptions.Add(new TimeBandDescription()
			{
				StartDate = today,
				Description = timebandDescription.Description,
				TimeBandId = timeBandId
			});
			timeBand.TimeBandDays.Add(new TimeBandDay()
			{
				StartDate = today,
				DayOfWeeks = dayOfWeekInt,
				TimeBandId = timeBandId
			});
			timeBand.TimeBandTimes.Add(new TimeBandTime()
			{
				StartDate = today,
				StartTimeOfDay = timebandTime.StartTimeOfDay,
				Duration = TimeBandUtil.ConvertDurationTimeToInt(viewModel.TimeBandTime.StartTimeOfDay, viewModel.TimeBandTime.EndTime, viewModel.TimeBandTime.NextDay),
				TimeBandId = timeBandId
			});
			return timeBand;
		}
		public static void EditDataModel(this TimeBand item, TimeBandEditViewModel viewModel)
		{
			item.TimeBandBase.Name = viewModel.Name;
			item.TimeBandBase.ParentId = viewModel.ChannelId;
			item.TimeBandBase.Description = viewModel.Description;
		}
	}
}
