using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Util;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.PositionRates
{
    public static class MappingExtension
	{
		public static PositionRateViewModel ToViewModel(this PositionRate item)
		{
			return new PositionRateViewModel()
			{
				Id = item.Id,
				Rate = item.Rate.ToDisplayPercent(),
				EndDate = item.EndDate,
				StartDate = item.StartDate,
				TimeBandId = item.TimeBandId,
				TimeBandName = item.TimeBand != null ? item.TimeBand.TimeBandBase.Name : null,
			};
		}
		public static IEnumerable<PositionRateViewModel> ToViewModel(this IQueryable<PositionRate> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static PositionRate ToDataModel(this PositionRateCreateViewModel viewModel)
		{
			return new PositionRate()
			{
				Id = Guid.NewGuid(),
				StartDate = viewModel.StartDate,
				TimeBandId = viewModel.TimeBandId,
				EndDate = viewModel.EndDate,
				Rate = viewModel.Rate.ToPercent(),
			};
		}
		public static void EditDataModel(this PositionRate positionRate, PositionRateEditViewModel viewModel)
		{
			var rate = Decimal.Parse(viewModel.Rate);
			positionRate.Rate = rate.ToPercent();
			positionRate.StartDate = viewModel.StartDate;
		//	positionRate.TimeBandId = viewModel.TimeBandId;
			positionRate.EndDate = viewModel.EndDate;

		}
	}
}
