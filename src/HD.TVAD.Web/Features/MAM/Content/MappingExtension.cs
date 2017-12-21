using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.MAM.Assets
{
    public static class MappingExtension
    {
        public static ContentViewModel ToViewModel(this ApplicationCore.Entities.Content asset)
        {
            return new ContentViewModel()
            {
                Id = asset.Id,
                Code = asset.Code,
                ProducerId = asset.ProducerId,
                ProducerName = asset.Producer != null ? asset.Producer.Name : null,
                ProductName = asset.ProductName,
                ProductModel = asset.ProductModel,
                BlockDuration = asset.BlockDuration,
                CreateTime = asset.CreateTime,
                TypeId = asset.TypeId,
                TypeName = asset.Type.Name,
                RegisterId = asset.RegisterId,
                RegisterName = asset.Register != null ? asset.Register.Name : null,
                ProductGroupId = asset.ProductGroupId,
                ProductGroupName = asset.ProductGroup != null ? asset.ProductGroup.Name : null,
                Approve = asset.Approve,
                ApproveEndDate = asset.ApproveEndDate,
                LastProductModel = asset.LastProductModel,
                LastProductModelName = asset.LastProductModel.HasValue ? asset.LastProductModelNavigation.ProductModel : null,
                Text = asset.Text
            };
        }
        public static IEnumerable<ContentViewModel> ToViewModel(this IQueryable<ApplicationCore.Entities.Content> items)
        {
            foreach (var item in items)
            {
                yield return item.ToViewModel();
            }
        }

		public static IQueryable<ContentViewModel> ToIQueryableViewModel(this IQueryable<ApplicationCore.Entities.Content> items)
		{
			return items.Select( asset => new ContentViewModel()
			{
				Id = asset.Id,
				Code = asset.Code,
				ProducerId = asset.ProducerId,
				ProducerName = asset.ProducerId.HasValue? asset.Producer.Name : "",
				ProductName = asset.ProductName,
				ProductModel = asset.ProductModel,
				BlockDuration = asset.BlockDuration,
				CreateTime = asset.CreateTime,
				TypeId = asset.TypeId,
				TypeName = asset.Type.Name,
				RegisterId = asset.RegisterId,
				RegisterName = asset.RegisterId.HasValue ? asset.Register.Name : "",
				ProductGroupId = asset.ProductGroupId,
				ProductGroupName = asset.ProductGroupId.HasValue ? asset.ProductGroup.Name : "",
				Approve = asset.Approve,
				ApproveEndDate = asset.ApproveEndDate,
				LastProductModel = asset.LastProductModel,
				LastProductModelName = asset.LastProductModel.HasValue ? asset.LastProductModelNavigation.ProductModel : null,
				Text = asset.Text
			});
		}
		public static DeleteViewModel ToDeleteViewModel(this ApplicationCore.Entities.Content item)
        {
            return new DeleteViewModel()
            {
                Id = item.Id,
            };
        }
        public static ApplicationCore.Entities.Content ToDataModel(this ContentCreateViewModel viewModel)
        {
            return new ApplicationCore.Entities.Content()
            {
                Id = Guid.NewGuid(),
            };
        }        
    }
}
