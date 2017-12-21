using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Util;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.SpotBlockRates
{
    public static class MappingExtension
	{
		public static SpotBlockRateViewModel ToViewModel(this SpotBlockRate item)
		{
			return new SpotBlockRateViewModel()
			{
				Id = item.Id,
				Rate = item.Rate.ToDisplayPercent(),
				SpotBlockDuration = item.SpotBlock.Duration,
				SpotBlockId = item.SpotBlockId,
				StartDate = item.StartDate,
				Description = item.Description,
			};
		}
		public static IEnumerable<SpotBlockRateViewModel> ToViewModel(this IQueryable<SpotBlockRate> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static SpotBlockRate ToDataModel(this SpotBlockRateCreateViewModel viewModel)
		{
			var rate = Decimal.Parse(viewModel.Rate);
			return new SpotBlockRate()
			{
				 Id = Guid.NewGuid(),
				Rate = rate.ToPercent(),
				SpotBlockId = viewModel.SpotBlockId,
				StartDate = viewModel.StartDate,
				Description = viewModel.Description
			};
		}
		public static void EditDataModel(this SpotBlockRate spotBlockRate, SpotBlockRateEditViewModel viewModel)
		{
			var rate = Decimal.Parse(viewModel.Rate);
			spotBlockRate.Rate = rate.ToPercent();
		//	spotBlockRate.StartDate = viewModel.StartDate;
			spotBlockRate.Description = viewModel.Description;

		}
	}
}
