using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TemplateItems
{
    public static class MappingExtension
	{
		public static TemplateItemViewModel ToViewModel(this TemplateItem item)
		{
			return new TemplateItemViewModel()
			{
				Id = item.Id,
				Index = item.Index,
				Name = item.Name,
				TemplateId = item.TemplateId,
			};
		}
		public static IEnumerable<TemplateItemViewModel> ToViewModel(this IQueryable<TemplateItem> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TemplateItem ToDataModel(this TemplateItemCreateViewModel viewModel)
		{
			return new TemplateItem()
			{
				 Id = Guid.NewGuid(),
				TemplateId = viewModel.TemplateId,
				Index = viewModel.Index,
				Name = viewModel.Name,
			};
		}
		public static void EditDataModel(this TemplateItem item, TemplateItemEditViewModel viewModel)
		{

		}
	}
}
