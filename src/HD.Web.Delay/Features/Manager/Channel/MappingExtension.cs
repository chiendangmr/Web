using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.Channels
{
    public static class MappingExtension
	{
		public static ChannelViewModel ToViewModel(this Channel item)
		{
			return new ChannelViewModel()
			{
				Id = item.Id,
				Name = item.TimeBandBase.Name,
				Description = item.TimeBandBase.Description,
				ParentId = item.TimeBandBase.ParentId,
			};
		}
		public static IEnumerable<ChannelViewModel> ToViewModel(this IQueryable<Channel> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static Channel ToDataModel(this ChannelCreateViewModel item)
		{
			return new Channel()
			{
				 Id = Guid.NewGuid(),
				 TimeBandBase = new TimeBandBase() {
					 Name = item.Name,
					 Description = item.Description,
					 ParentId = item.ParentId,					 
				 }
			};
		}
		public static void EditDataModel(this Channel item, ChannelEditViewModel viewModel)
		{
			item.TimeBandBase.ParentId = viewModel.ParentId;
			item.TimeBandBase.Description = viewModel.Description;
			item.TimeBandBase.Name = viewModel.Name;
		}
	}
}
