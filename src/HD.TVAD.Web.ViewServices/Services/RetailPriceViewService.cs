using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Price;
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
	[Service(ServiceType = typeof(IRetailPriceViewService))]
	public class RetailPriceViewService : IRetailPriceViewService
	{
		private readonly IGetTypeService _getTypeService;
		public RetailPriceViewService(
			IGetTypeService getTypeService)
		{
			_getTypeService = getTypeService;
		}

		public async Task<IEnumerable<SelectListItem>> GetRetailTypeSelectListItemAsync()
		{
			var retailTypeSelectItems = await _getTypeService.GetRetailTypes()
				.Select(c => new SelectListItem()
			{
				Value = c.Id.ToString(),
				Text = c.Description,
			}).ToListAsync();

			return retailTypeSelectItems;
		}
	}
}
