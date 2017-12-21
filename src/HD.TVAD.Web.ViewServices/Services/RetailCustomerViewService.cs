using HD.Station;
using HD.TVAD.ApplicationCore.Entities.ContractSchema;
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
	[Service(ServiceType = typeof(IRetailCustomerViewService))]
	public class RetailCustomerViewService : ViewService, IRetailCustomerViewService
	{
		private readonly IRetailCustomerService _retailCustomerService;
		private readonly IGetTypeService _getTypeService;
		public RetailCustomerViewService(IRetailCustomerService retailCustomerService,
			IGetTypeService getTypeService)
		{
			_retailCustomerService = retailCustomerService;
			_getTypeService = getTypeService;
		}
		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var list = await _retailCustomerService.GetAll()
					.OrderBy(a => a.Customer.Name)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Customer.Name
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
