using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandPrices
{
	public static class MappingExtension
	{
		public static TimeBandPriceViewModel ToViewModel(this TimeBandPrice item)
		{
			return new TimeBandPriceViewModel()
			{
				Id = item.Id,
				Price = item.Price,
				SpotBlockDuration = item.SpotBlock.Duration,
				SpotBlockId = item.SpotBlockId,
				StartDate = item.StartDate,
				TimeBandId = item.TimeBandId,
				TimeBandName = item.TimeBand.TimeBandBase.Name,
			};
		}
		public static IEnumerable<TimeBandPriceViewModel> ToViewModel(this IQueryable<TimeBandPrice> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandPrice ToDataModel(this TimeBandPriceCreateViewModel viewModel)
		{
			return new TimeBandPrice()
			{
				Id = Guid.NewGuid(),
				Price = viewModel.Price,
				SpotBlockId = viewModel.SpotBlockId,
				StartDate = viewModel.StartDate,
				TimeBandId = viewModel.TimeBandId,
			};
		}
		public static void EditDataModel(this TimeBandPrice timeBandPrice, TimeBandPriceEditViewModel viewModel)
		{
		//	timeBandPrice.TimeBandId = viewModel.TimeBandId;
		//	timeBandPrice.SpotBlockId = viewModel.SpotBlockId;
			timeBandPrice.StartDate = viewModel.StartDate;
			timeBandPrice.Price = viewModel.Price;
		}
	}
}
