using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.Producers
{
    public static class MappingExtension
	{
		public static ProducerViewModel ToViewModel(this Producer item)
		{
			return new ProducerViewModel()
			{
				Id = item.Id,
				Description = item.Description,
				Name = item.Name,
				ParentId = item.ParentId,
			//	ParentName = item.Parent.Name,
			};
		}
		public static IEnumerable<ProducerViewModel> ToViewModel(this IQueryable<Producer> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static DeleteViewModel ToDeleteViewModel(this Producer item)
		{
			return new DeleteViewModel()
			{
				Id = item.Id,
				Name = item.Name.ToString(),
			};
		}
		public static Producer ToDataModel(this ProducerCreateViewModel viewModel)
		{
			return new Producer()
			{
				 Id = Guid.NewGuid(),
				Description = viewModel.Description,
				Name = viewModel.Name,
				ParentId = viewModel.ParentId,
			};
		}
		public static void EditDataModel(this Producer producer, ProducerEditViewModel viewModel)
		{
			producer.Name = viewModel.Name;
			producer.ParentId = viewModel.ParentId;
			producer.Description = viewModel.Description;
		}
	}
}
