using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.Booking
{
    public static class MappingExtension
	{
		public static SpotBlockViewModel ToViewModel(this SpotBlock item)
		{
			return new SpotBlockViewModel()
			{
				Id = item.Id,
				Length = item.Duration,
				Description = item.Description,
			};
		}
		public static IEnumerable<SpotBlockViewModel> ToViewModel(this IQueryable<SpotBlock> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static SpotBlock ToDataModel(this SpotBlockCreateViewModel item)
		{
			return new SpotBlock()
			{
				 Id = Guid.NewGuid(),
				 Duration = item.Length,
				 Description = item.Description,
			};
		}
		public static void EditDataModel(this SpotBlock item, SpotBlockEditViewModel viewModel)
		{
			item.Description = viewModel.Description;
		//	item.Duration = viewModel.Length;
		}
	}
}
