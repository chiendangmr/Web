using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandDescriptions
{
    public static class MappingExtension
	{
		public static TimeBandDescriptionViewModel ToViewModel(this TimeBandDescription item)
		{
			return new TimeBandDescriptionViewModel()
			{
				Id = item.Id,
				Description = item.Description,
				StartDate = item.StartDate,
				EndDate = item.EndDate
			};
		}
		public static IEnumerable<TimeBandDescriptionViewModel> ToViewModel(this IQueryable<TimeBandDescription> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandDescription ToDataModel(this TimeBandDescriptionCreateViewModel formModel)
		{
			return new TimeBandDescription()
			{
				 Id = Guid.NewGuid(),
				TimeBandId = formModel.TimeBandId,
				StartDate = formModel.StartDate,
				EndDate = formModel.EndDate,
				Description = formModel.Description
			};
		}
		public static void EditDataModel(this TimeBandDescription timebandDescription, TimeBandDescriptionEditViewModel viewModel)
		{
			timebandDescription.Description = viewModel.Description;
			timebandDescription.EndDate = viewModel.EndDate;
			timebandDescription.StartDate = viewModel.StartDate;
		}
	}
}
