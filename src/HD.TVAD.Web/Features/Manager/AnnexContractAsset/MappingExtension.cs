using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.AnnexContractAssets
{
    public static class MappingExtension
	{
		public static AnnexContractAssetViewModel ToViewModel(this AnnexContractAsset item)
		{
			return new AnnexContractAssetViewModel()
			{
				Id = item.Id,
				AnnexContractId = item.AnnexContractId,
				AssetId = item.ContentId,
				PriceTypeDetailId = item.PriceTypeDetailId,
				AssetBlockDuration = item.Content.BlockDuration,
				AssetCode = item.Content.Code,
				AssetProductName = item.Content.ProductName,
				Content = item.Contents,
				Price = item.Price,
				PriceTypeDetailName = item.PriceTypeDetail.Name,
				BookingTypeId = item.AnnexContract.BookingTypeId,
			};
		}
		public static IEnumerable<AnnexContractAssetViewModel> ToViewModel(this IQueryable<AnnexContractAsset> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static AnnexContractAsset ToDataModel(this AnnexContractAssetCreateViewModel viewModel)
		{
			return new AnnexContractAsset()
			{
				 Id = Guid.NewGuid(),	
				AnnexContractId = viewModel.AnnexContractId,
				ContentId = viewModel.AssetId,
				PriceTypeDetailId = viewModel.PriceTypeDetailId,
				Price = viewModel.Price,
				Contents = viewModel.Content
			};
		}
		public static AnnexContractAsset ToDataModel(this AnnexContractAssetForNormalBookingCreateViewModel viewModel)
		{
			return new AnnexContractAsset()
			{
				Id = Guid.NewGuid(),
				AnnexContractId = viewModel.AnnexContractId,
				ContentId = viewModel.AssetId,
				PriceTypeDetailId = viewModel.PriceTypeDetailId,
			//	Price = viewModel.Price,
			//	Contents = viewModel.Content
			};
		}
		public static void EditDataModel(this AnnexContractAsset annexContractAsset, AnnexContractAssetEditViewModel viewModel)
		{
			annexContractAsset.Price = viewModel.Price;
			annexContractAsset.PriceTypeDetailId = viewModel.PriceTypeDetailId;
			annexContractAsset.ContentId = viewModel.AssetId;
			annexContractAsset.Contents = viewModel.Content;
		}
	}
}
