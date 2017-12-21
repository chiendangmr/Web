using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.Templates
{
	public static class MappingExtension
	{
		public static TemplateViewModel ToViewModel(this Template item)
		{
			return new TemplateViewModel()
			{
				Id = item.Id,
				Name = item.Name,
			};
		}
		public static IEnumerable<TemplateViewModel> ToViewModel(this IQueryable<Template> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static Template ToDataModel(this TemplateCreateViewModel viewModel)
		{
			return new Template()
			{
				Id = Guid.NewGuid(),
				Name = viewModel.Name,
			};
		}
		public static void EditDataModel(this Template template, TemplateEditViewModel viewModel)
		{
			template.Name = viewModel.Name;
		}
	}
}
