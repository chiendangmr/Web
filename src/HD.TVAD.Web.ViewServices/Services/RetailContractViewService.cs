using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Booking;
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
	[Service(ServiceType = typeof(IRetailContractViewService))]
	public class RetailContractViewService : ViewService, IRetailContractViewService
	{
		private readonly IRetailContractService _retailContractService;
		private readonly IGetTypeService _getTypeService;
		public RetailContractViewService(IRetailContractService retailContractService,
			IGetTypeService getTypeService)
		{
			_retailContractService = retailContractService;
			_getTypeService = getTypeService;
		}
		
		public async Task<IEnumerable<SelectListItem>> GetCodeListAsync()
		{
			try
			{
				var annexContractSelectItems = await _retailContractService.GetAll()
					.OrderBy(c => c.AnnexContract.Code)
					.Select(a => new SelectListItem()
					{
						Text = a.AnnexContract.Code,
					}).ToListAsync();
				return annexContractSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var annexContractSelectItems = await _retailContractService.GetAll()
					.OrderBy(c => c.AnnexContract.Code)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.AnnexContract.Code,
					}).ToListAsync();
				return annexContractSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
