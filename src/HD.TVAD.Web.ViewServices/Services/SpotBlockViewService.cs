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
	[Service(ServiceType = typeof(ISpotBlockViewService))]
	public class SpotBlockViewService : ViewService, ISpotBlockViewService
	{
		private readonly ISpotBlockService _spotBlockService;
		public SpotBlockViewService(ISpotBlockService spotBlockService)
		{
			_spotBlockService = spotBlockService;
		}
		public IEnumerable<SelectListItem> GetDurationList() {
			try
			{
				var list = _spotBlockService.GetAll()
					.OrderBy(c => c.Duration)
					.Select(a => new SelectListItem()
					{
						Text = a.Duration.ToString(),
					}).ToList();
				return list;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async override Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var list = await _spotBlockService.GetAll()
					.OrderBy(c => c.Duration)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Duration.ToString(),
					}).ToListAsync();

				return list;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
