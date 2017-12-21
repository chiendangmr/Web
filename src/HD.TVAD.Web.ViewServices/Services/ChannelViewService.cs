using HD.Station;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.ViewServices
{
	[Service(ServiceType = typeof(IChannelViewService))]
	public class ChannelViewService : ViewService, IChannelViewService
	{
		private readonly IChannelService _channelService;
		public ChannelViewService(IChannelService channelService)
		{
			_channelService = channelService;
		}
		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var channelSelectItems = await _channelService.GetAll()
					.OrderBy(c => c.TimeBandBase.Name)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.TimeBandBase.Name
					}).ToListAsync();
				return channelSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
