using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Features.Manager.TimeBands;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandDays
{
    public static class MappingExtension
	{
		public static TimeBandDayViewModel ToViewModel(this TimeBandDay item)
		{
			return new TimeBandDayViewModel()
			{
				Id = item.Id,
				DayOfWeeks = item.DayOfWeeks,
				EndDate = item.EndDate,
				StartDate = item.StartDate,
				TimeBandId = item.TimeBandId,
				DayOfWeekView = TimeBandUtil.ConvertDayOfWeekEnumToDayOfWeekViewModel((VisibleDayOfWeek)item.DayOfWeeks),
			};
		}
		public static IEnumerable<TimeBandDayViewModel> ToViewModel(this IQueryable<TimeBandDay> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandDay ToDataModel(this TimeBandDayCreateViewModel formModel)
		{

			var dayOfWeekInt = TimeBandUtil.ConvertDayOfWeekViewToSumInt(formModel.DayOfWeekView);
			return new TimeBandDay()
			{
				 Id = Guid.NewGuid(),
				TimeBandId = formModel.TimeBandId,
				StartDate = formModel.StartDate,
				EndDate = formModel.EndDate,
				DayOfWeeks = dayOfWeekInt
			};
		}
		public static void EditDataModel(this TimeBandDay timeBandDay, TimeBandDayEditViewModel viewModel)
		{
			timeBandDay.StartDate = viewModel.StartDate;
			timeBandDay.EndDate = viewModel.EndDate;
			timeBandDay.DayOfWeeks = TimeBandUtil.ConvertDayOfWeekViewToSumInt(viewModel.DayOfWeekView);
		}
	}
}
