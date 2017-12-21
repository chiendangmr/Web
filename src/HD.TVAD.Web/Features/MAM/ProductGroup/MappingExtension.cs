using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.ProductGroups
{
    public static class MappingExtension
	{
		public static ProductGroupViewModel ToViewModel(this ProductGroup item)
		{
			return new ProductGroupViewModel()
			{
				Id = item.Id,
				Description = item.Description,
				Name = item.Name,
				Code = item.Code,
				ParentId = item.ParentId
			};
		}
		public static IEnumerable<ProductGroupViewModel> ToViewModel(this IQueryable<ProductGroup> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static DeleteViewModel ToDeleteViewModel(this ProductGroup item)
		{
			return new DeleteViewModel()
			{
				Id = item.Id,
				Name = item.Name.ToString(),
			};
		}
		public static ProductGroup ToDataModel(this ProductGroupCreateViewModel viewModel)
		{
			return new ProductGroup()
			{
				 Id = Guid.NewGuid(),
				Description = viewModel.Description,
				Name = viewModel.Name,
				ParentId = viewModel.ParentId,
				Code = viewModel.Code,
			};
		}
		public static void EditDataModel(this ProductGroup productGroup, ProductGroupEditViewModel viewModel)
		{
			productGroup.Name = viewModel.Name;
         //   productGroup.Code = viewModel.Code;
		//	productGroup.ParentId = viewModel.ParentId;
			productGroup.Description = viewModel.Description;
		}
	}
}
