using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandSliceDurations
{
    public static class MappingExtension
	{
		public static TimeBandSliceDurationViewModel ToViewModel(this TimeBandSliceDuration item)
		{
			return new TimeBandSliceDurationViewModel()
			{
				Id = item.Id,
				TimeBandSliceId = item.TimeBandSliceId,
				StartDate = item.StartDate,
				EndDate = item.EndDate,
				Duration = item.Duration,				
			};
		}
		public static IEnumerable<TimeBandSliceDurationViewModel> ToViewModel(this IQueryable<TimeBandSliceDuration> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandSliceDuration ToDataModel(this TimeBandSliceDurationCreateViewModel viewModel)
		{
			return new TimeBandSliceDuration()
			{
				 Id = Guid.NewGuid(),
				TimeBandSliceId = viewModel.TimeBandSliceId,
				StartDate = viewModel.StartDate,
				EndDate = viewModel.EndDate,
				Duration = viewModel.Duration
			};
		}
		public static void EditDataModel(this TimeBandSliceDuration timeBandSliceDuration, TimeBandSliceDurationEditViewModel viewModel)
		{
			timeBandSliceDuration.Duration = viewModel.Duration;
			timeBandSliceDuration.EndDate = viewModel.EndDate;
			timeBandSliceDuration.StartDate = viewModel.StartDate;
		}
	}
}
