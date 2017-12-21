using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TemplateItemAssetTypeRequests
{
    public static class MappingExtension
	{
		public static TemplateItemAssetTypeRequestViewModel ToViewModel(this TemplateItemAssetTypeRequest item)
		{
			return new TemplateItemAssetTypeRequestViewModel()
			{
				Id = item.Id,
				AssetTypeId = item.AssetTypeId,
				AssetTypeName = item.AssetType.Name,
				MaxCount = item.MaxCount,
				MinCount = item.MinCount,
				TemplateItemId = item.TemplateItemId,
			};
		}
		public static IEnumerable<TemplateItemAssetTypeRequestViewModel> ToViewModel(this IQueryable<TemplateItemAssetTypeRequest> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TemplateItemAssetTypeRequest ToDataModel(this TemplateItemAssetTypeRequestCreateViewModel viewModel)
		{
			return new TemplateItemAssetTypeRequest()
			{
				 Id = Guid.NewGuid(),
				TemplateItemId = viewModel.TemplateItemId,
				AssetTypeId = viewModel.AssetTypeId,
				MinCount = viewModel.MinCount,
				MaxCount = viewModel.MaxCount
			};
		}
		public static void EditDataModel(this TemplateItemAssetTypeRequest templateItemAssetTypeRequest, TemplateItemAssetTypeRequestEditViewModel viewModel)
		{
			templateItemAssetTypeRequest.MinCount = viewModel.MinCount;
			templateItemAssetTypeRequest.MaxCount = viewModel.MaxCount;
		//	templateItemAssetTypeRequest.AssetTypeId = viewModel.AssetTypeId;
		}
	}
}
