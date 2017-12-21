using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Util;
using HD.TVAD.Web.Models;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.RateSpotBlocks
{
    public static class MappingExtension
	{
		public static RateSpotBlockViewModel ToViewModel(this RateSpotBlock item, IStringLocalizer<RateSpotBlockController> localizer)
		{
			return new RateSpotBlockViewModel()
			{
				Id = item.Id,
				Name = localizer[item.TypeDetail.Name].Value,
				Rate = item.Rate.ToDisplayPercent(),
				SpotBlockDuration = item.SpotBlock.Duration,
				SpotBlockId = item.SpotBlockId,
				TypeId = item.TypeDetail.TypeId,
				TypeName = localizer[item.TypeDetail.Type.Name].Value,
			};
		}
		public static IEnumerable<RateSpotBlockViewModel> ToViewModel(this IQueryable<RateSpotBlock> items, IStringLocalizer<RateSpotBlockController> localizer)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel(localizer);
			}
		}

		public static RateSpotBlock ToDataModel(this RateSpotBlockCreateViewModel viewModel)
		{
			return new RateSpotBlock()
			{
				Id = Guid.NewGuid(),
				Rate = viewModel.Rate.ToPercent(),
				SpotBlockId = viewModel.SpotBlockId,
				TypeDetail = new TypeDetail()
				{
					Name = viewModel.Name,
					TypeId = viewModel.TypeId
				}
			};
		}
		public static void EditDataModel(this RateSpotBlock rateSpotBlock, RateSpotBlockEditViewModel viewModel)
		{
			var rate = Decimal.Parse(viewModel.Rate);
			rateSpotBlock.Rate = rate.ToPercent();
		//	rateSpotBlock.SpotBlockId = viewModel.SpotBlockId;
		//	rateSpotBlock.TypeDetail.TypeId = viewModel.TypeId;
			rateSpotBlock.TypeDetail.Name = viewModel.Name;
		}
	}
}
