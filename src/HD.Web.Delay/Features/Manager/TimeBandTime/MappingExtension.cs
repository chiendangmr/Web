using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandTimes
{
    public static class MappingExtension
	{
		public static TimeBandTimeViewModel ToViewModel(this TimeBandTime item)
		{
			return new TimeBandTimeViewModel()
			{
				Id = item.Id,
				StartDate = item.StartDate,
				EndDate = item.EndDate,
				Duration = item.Duration,
				StartTimeOfDay = item.StartTimeOfDay,
				TimeBandId = item.TimeBandId
			};
		}
		public static TimeBandTimeViewModel ToEditViewModel(this TimeBandTime item)
		{
			var endTime = new TimeSpan();
			var nextDay = false;
			var duration = item.Duration;
			var durationLeftTo24h = new TimeSpan(24, 0, 0) - item.StartTimeOfDay;
			var durationTimeSpan = new TimeSpan(0, 0, duration);
			if (durationTimeSpan < durationLeftTo24h) // in day
			{
				endTime = item.StartTimeOfDay + durationTimeSpan;
			}
			else
			{
				nextDay = true;
				endTime = durationTimeSpan - durationLeftTo24h;
			}

			return new TimeBandTimeViewModel()
			{
				Id = item.Id,
				Duration = item.Duration,
				TimeBandId = item.TimeBandId,
				StartDate = item.StartDate,
				EndDate = item.EndDate,
				StartTimeOfDay = item.StartTimeOfDay,
				EndTime = endTime,
				NextDay = nextDay,
			};
		}
		public static IEnumerable<TimeBandTimeViewModel> ToViewModel(this IQueryable<TimeBandTime> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandTime ToDataModel(this TimeBandTimeCreateViewModel formModel)
		{
			return new TimeBandTime()
			{
				 Id = Guid.NewGuid(),
				TimeBandId = formModel.TimeBandId,
				StartDate = formModel.StartDate,
				EndDate = formModel.EndDate,
				StartTimeOfDay = formModel.StartTimeOfDay,
				Duration = TimeBandUtil.ConvertDurationTimeToInt(formModel.StartTimeOfDay, formModel.EndTime, formModel.NextDay)
			};
		}
		public static void EditDataModel(this TimeBandTime timeBandTime, TimeBandTimeEditViewModel viewModel)
		{
			timeBandTime.Duration = TimeBandUtil.ConvertDurationTimeToInt(viewModel.StartTimeOfDay, viewModel.EndTime, viewModel.NextDay);
			timeBandTime.StartTimeOfDay = viewModel.StartTimeOfDay;
			timeBandTime.EndDate = viewModel.EndDate;
			timeBandTime.StartDate = viewModel.StartDate;
		}
	}
}
