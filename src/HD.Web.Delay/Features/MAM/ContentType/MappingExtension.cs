using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.ContentTypes
{
    public static class MappingExtension
	{
		public static AssetTypeViewModel ToViewModel(this ContentType item)
		{
			return new AssetTypeViewModel()
			{
				Id = item.Id,
				Description = item.Description,
				Name = item.Name,
				FileTypeId = item.FileTypeId,
				FileTypeName = item.FileType.Name,
				Index = item.Index,
				IsBroadcast = item.IsBroadcast,
				IsIndexing = item.IsIndexing
			};
		}
		public static IEnumerable<AssetTypeViewModel> ToViewModel(this IQueryable<ContentType> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static DeleteViewModel ToDeleteViewModel(this ContentType item)
		{
			return new DeleteViewModel()
			{
				Id = item.Id,
				Name = item.Name.ToString(),
			};
		}
		public static ContentType ToDataModel(this AssetTypeCreateViewModel viewModel)
		{
			return new ContentType()
			{
				 Id = Guid.NewGuid(),
				Description = viewModel.Description,
				Name = viewModel.Name,
				Index = viewModel.Index,
				IsIndexing = viewModel.IsIndexing,
				IsBroadcast = viewModel.IsBroadcast,
				FileTypeId = viewModel.FileTypeId,
			};
		}
		public static void EditDataModel(this ContentType assetType, AssetTypeEditViewModel viewModel)
		{
		//	assetType.Name = viewModel.Name;
			assetType.Description = viewModel.Description;
		//	assetType.FileTypeId = viewModel.FileTypeId;
			assetType.Index = viewModel.Index;
			assetType.IsBroadcast = viewModel.IsBroadcast;
			assetType.IsIndexing = viewModel.IsIndexing;
		}
	}
}
