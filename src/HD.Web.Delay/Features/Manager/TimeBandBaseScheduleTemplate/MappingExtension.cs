using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.TimeBandBaseScheduleTemplates
{
    public static class MappingExtension
	{
		public static TimeBandBaseScheduleTemplateViewModel ToViewModel(this TimeBandBaseScheduleTemplate item)
		{
			return new TimeBandBaseScheduleTemplateViewModel()
			{
				Id = item.Id,
				EndDate = item.EndDate,
				StartDate = item.StartDate,
				TemplateId = item.ScheduleTemplate.Id,
				TimeBandBaseId = item.TimeBandBaseId,
				TimeBandBaseName = item.TimeBandBase.Name,
			};
		}
		public static IEnumerable<TimeBandBaseScheduleTemplateViewModel> ToViewModel(this IQueryable<TimeBandBaseScheduleTemplate> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static TimeBandBaseScheduleTemplate ToDataModel(this TimeBandBaseScheduleTemplateCreateViewModel viewModel)
		{
			return new TimeBandBaseScheduleTemplate()
			{
				Id = Guid.NewGuid(),
				ScheduleTemplateId = viewModel.TemplateId,
				TimeBandBaseId = viewModel.TimeBandBaseId,
				EndDate = viewModel.EndDate,
				StartDate = viewModel.StartDate,
			};
		}
		public static void EditDataModel(this TimeBandBaseScheduleTemplate timeBandBaseScheduleTemplate, TimeBandBaseScheduleTemplateEditViewModel viewModel)
		{
		//	timeBandBaseScheduleTemplate.TimeBandBaseId = viewModel.TimeBandBaseId;
		//	timeBandBaseScheduleTemplate.StartDate = viewModel.StartDate;
			timeBandBaseScheduleTemplate.EndDate = viewModel.EndDate;
		}
	}
}
