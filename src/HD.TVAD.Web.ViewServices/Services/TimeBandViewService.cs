using HD.Station;
using HD.TVAD.ApplicationCore.Util;
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
	[Service(ServiceType = typeof(ITimeBandViewService))]
	public class TimeBandViewService : ViewService, ITimeBandViewService
	{
		private readonly ITimeBandService _timeBandService;
		private readonly ITimeBandSliceService _timeBandSliceService;
		public TimeBandViewService(ITimeBandService timeBandService,
			ITimeBandSliceService timeBandSliceService)
		{
			_timeBandService = timeBandService;
			_timeBandSliceService = timeBandSliceService;
		}
		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			var timeBandSelectItems = await _timeBandService.GetAll()
				.OrderBy(t => Util.GetValueToSort(t.TimeBandBase.Name))
				.Select(a => new SelectListItem()
				{
					Value = a.Id.ToString(),
					Text = a.TimeBandBase.Name
				}).ToListAsync();
			return timeBandSelectItems;
		}

		public async Task<IEnumerable<SelectListItem>> GetTimeBandOfChannelListAsync(Guid channelId)
		{
			var timeBands = await _timeBandService.GetAllTimeBandByChannelIdAsync(channelId);

			var timeBandSliceSelectItems = timeBands
				.OrderBy(t => Util.GetValueToSort(t.TimeBandBase.Name))
				.Select(t => new SelectListItem()
				{
					Value = t.Id.ToString(),
					Text = t.TimeBandName
				}).ToList();

			return timeBandSliceSelectItems;
		}

		public async Task<IEnumerable<SelectListItem>> GetTimeBandSliceSelectItemsListAsync(Guid timeBandId)
		{
			var timeBandSliceSelectItems = await _timeBandSliceService.GetAll()
				.Where(s => s.TimeBandId == timeBandId)
				.OrderBy(t => Util.GetValueToSort(t.Name))
				.Select(t => new SelectListItem()
				{
					Value = t.Id.ToString(),
					Text = t.Name
				}).ToListAsync();
			return timeBandSliceSelectItems;

		}
	}
}
