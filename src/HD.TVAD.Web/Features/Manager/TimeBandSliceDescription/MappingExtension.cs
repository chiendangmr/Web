using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandSliceDescriptions
{
    public static class MappingExtension
	{
		public static TimeBandSliceDescriptionViewModel ToViewModel(this TimeBandSliceDescription item)
		{
			return new TimeBandSliceDescriptionViewModel()
			{
				Id = item.Id,
				Description = item.Description,
				EndDate = item.EndDate,
				TimeBandSliceId = item.TimeBandSliceId,
				StartDate = item.StartDate,
			};
		}
		public static IEnumerable<TimeBandSliceDescriptionViewModel> ToViewModel(this IQueryable<TimeBandSliceDescription> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandSliceDescription ToDataModel(this TimeBandSliceDescriptionCreateViewModel viewModel)
		{
			return new TimeBandSliceDescription()
			{
				 Id = Guid.NewGuid(),
				TimeBandSliceId = viewModel.TimeBandSliceId,
				StartDate = viewModel.StartDate,
				EndDate = viewModel.EndDate,
				Description = viewModel.Description
			};
		}
		public static void EditDataModel(this TimeBandSliceDescription timeBandSliceDescription, TimeBandSliceDescriptionEditViewModel viewModel)
		{
			timeBandSliceDescription.Description = viewModel.Description;
			timeBandSliceDescription.EndDate = viewModel.EndDate;
			timeBandSliceDescription.StartDate = viewModel.StartDate;
		}
	}
}
