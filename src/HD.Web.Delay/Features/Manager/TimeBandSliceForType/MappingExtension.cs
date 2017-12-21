using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandSliceForTypes
{
    public static class MappingExtension
	{
		public static TimeBandSliceForTypeViewModel ToViewModel(this TimeBandSliceForType item)
		{
			return new TimeBandSliceForTypeViewModel()
			{
				BookingTypeId = item.TypeId,
				BookingTypeName = item.Type.Name,
				EndDate = item.EndDate,
				Id = item.Id,
				StartDate = item.StartDate,
				TimeBandName = item.TimeBandSlice.TimeBand.TimeBandBase.Name,
				TimeBandSliceId = item.TimeBandSliceId,
				TimeBandSliceName = item.TimeBandSlice.Name,
				TimeBandId = item.TimeBandSlice.TimeBandId,
			};
		}
		public static IEnumerable<TimeBandSliceForTypeViewModel> ToViewModel(this IQueryable<TimeBandSliceForType> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandSliceForType ToDataModel(this TimeBandSliceForTypeCreateViewModel viewModel)
		{
			return new TimeBandSliceForType()
			{
				 Id = Guid.NewGuid(),
				EndDate = viewModel.EndDate,
				StartDate = viewModel.StartDate,
				TimeBandSliceId = viewModel.TimeBandSliceId,
				TypeId = viewModel.BookingTypeId
			};
		}
		public static void EditDataModel(this TimeBandSliceForType timeBandSliceForType, TimeBandSliceForTypeEditViewModel viewModel)
		{
			timeBandSliceForType.StartDate = viewModel.StartDate;
			timeBandSliceForType.TimeBandSliceId = viewModel.TimeBandSliceId;
		//	timeBandSliceForType.TypeId = viewModel.BookingTypeId;
			timeBandSliceForType.EndDate = viewModel.EndDate;
		}
	}
}
