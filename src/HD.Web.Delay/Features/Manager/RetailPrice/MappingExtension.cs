using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.RetailPrices
{
	public static class MappingExtension
	{
		public static RetailPriceViewModel ToViewModel(this RetailPrice item)
		{
			return new RetailPriceViewModel()
			{
				Id = item.Id,
				RetailTypeId = item.RetailTypeId,
				Price = item.Price,
				RetailTypeDescription = item.RetailType.Description,
				StartDate = item.StartDate,
				TypeDetailName = item.RetailType.TypeDetail.Name
			};
		}
		public static IEnumerable<RetailPriceViewModel> ToViewModel(this IQueryable<RetailPrice> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static RetailPrice ToDataModel(this RetailPriceCreateViewModel viewModel)
		{
			return new RetailPrice()
			{
				Id = Guid.NewGuid(),
				Price = viewModel.Price,
				StartDate = viewModel.StartDate,
				RetailTypeId = viewModel.RetailTypeId
			};
		}
		public static void EditDataModel(this RetailPrice retailPrice, RetailPriceEditViewModel viewModel)
		{
			retailPrice.Price = viewModel.Price;
		//	retailPrice.RetailTypeId = viewModel.RetailTypeId;
			retailPrice.StartDate = viewModel.StartDate;
		}
	}
}
