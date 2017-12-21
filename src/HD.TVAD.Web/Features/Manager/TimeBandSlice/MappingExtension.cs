using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandSlices
{
    public static class MappingExtension
	{
		public static TimeBandSliceViewModel ToViewModel(this TimeBandSlice item)
		{
			var timeBandSliceDescription = item.TimeBandSliceDescriptions
				.Where(t => t.StartDate <= DateTime.Today)
				.OrderByDescending(t => t.StartDate)
				.FirstOrDefault();
			var desscription = timeBandSliceDescription != null ? timeBandSliceDescription.Description : null;

			var timeBandSliceDuration = item.TimeBandSliceDurations
				.Where(t => t.StartDate <= DateTime.Today)
				.OrderByDescending(t => t.StartDate)
				.FirstOrDefault();
			var maxDuration = timeBandSliceDuration != null ? timeBandSliceDuration.Duration : 0;
			var maxDurationId = timeBandSliceDuration != null ? timeBandSliceDuration.Id : Guid.Empty;

			return new TimeBandSliceViewModel()
			{
				Id = item.Id,
				Name = item.Name,
				TimeBandName = item.TimeBand.TimeBandBase.Name,
				Description = desscription,
				MaxDuration = maxDuration,
				MaxDurationId = maxDurationId,
			};
		}
		public static IEnumerable<TimeBandSliceViewModel> ToViewModel(this IQueryable<TimeBandSlice> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandSlice ToDataModel(this TimeBandSliceCreateViewModel viewModel)
		{
			var today = DateTime.Today;
			var timeBandSliceId = Guid.NewGuid();
			var timeBandSlice = new TimeBandSlice()
			{
				Name = viewModel.Name,
				TimeBandId = viewModel.TimeBandId
			};
			timeBandSlice.TimeBandSliceDescriptions.Add(new TimeBandSliceDescription()
			{
				StartDate = today,
				Description = viewModel.Description.Description,
				TimeBandSliceId = timeBandSliceId
			});
			timeBandSlice.TimeBandSliceDurations.Add(new TimeBandSliceDuration()
			{
				StartDate = today,
				Duration = viewModel.Duration.Duration,
				TimeBandSliceId = timeBandSliceId
			});

			return timeBandSlice;
		}
		public static void EditDataModel(this TimeBandSlice timeBandSlice, TimeBandSliceEditViewModel viewModel)
		{
			timeBandSlice.Name = viewModel.Name;
		}
	}
}
