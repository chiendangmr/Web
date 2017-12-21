using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Price;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.ViewServices
{
	[Service(ServiceType = typeof(IRateSpotBlockViewService))]
	public class RateSpotBlockViewService : IRateSpotBlockViewService
	{
		private readonly IGetTypeService _getTypeService;
		private IStringLocalizer<RateSpotBlockViewService> _localizer;
		public RateSpotBlockViewService(
			IGetTypeService getTypeService,
			IStringLocalizer<RateSpotBlockViewService> localizer)
		{
			_getTypeService = getTypeService;
			_localizer = localizer;
		}

		public async Task<IEnumerable<SelectListItem>> GetPriceTypeSelectListItemAsync()
		{
			try
			{
				var priceTypeSelectItems = await _getTypeService.GetPriceTypes()
					.Where(t => t.Id == (int)PriceTypeEnum.Rate || t.Id == (int)PriceTypeEnum.RateByBlock)
					.Select(c => new SelectListItem()
					{
						Value = c.Id.ToString(),
						Text = _localizer[c.Name].Value,
					}).ToListAsync();
				return priceTypeSelectItems;

			}
			catch (Exception)
			{

				throw;
			}

		}
	}
}
