using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandSliceDurationByTypes
{
    public static class MappingExtension
	{
		public static TimeBandSliceDurationByTypeViewModel ToViewModel(this TimeBandSliceDurationByType item, IStringLocalizer<TimeBandSliceDurationByTypeController> localizer)
		{
			return new TimeBandSliceDurationByTypeViewModel()
			{
				Id = item.Id,
				Duration = item.Duration,
				BookingTypeId = item.TypeId,
				BookingTypeName =  localizer[item.Type.Name].Value
			};
		}
		public static IEnumerable<TimeBandSliceDurationByTypeViewModel> ToViewModel(this IQueryable<TimeBandSliceDurationByType> items, IStringLocalizer<TimeBandSliceDurationByTypeController> localizer)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel(localizer);
			}
		}

		public static TimeBandSliceDurationByType ToDataModel(this TimeBandSliceDurationByTypeCreateViewModel viewModel)
		{
			return new TimeBandSliceDurationByType()
			{
				 Id = Guid.NewGuid(),
				TypeId = viewModel.BookingTypeId,
				TimeBandSliceDurationId = viewModel.TimeBandSliceDurationId,
				Duration = viewModel.Duration
			};
		}
		public static void EditDataModel(this TimeBandSliceDurationByType timeBandSliceDurationByType, TimeBandSliceDurationByTypeEditViewModel viewModel)
		{
	//		timeBandSliceDurationByType.TypeId = viewModel.BookingTypeId;
			timeBandSliceDurationByType.Duration = viewModel.Duration;
		}
	}
}
