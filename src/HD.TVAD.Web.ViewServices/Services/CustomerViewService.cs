using HD.Station;
using HD.TVAD.ApplicationCore.Entities.ContractSchema;
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
	[Service(ServiceType = typeof(ICustomerViewService))]
	public class CustomerViewService : ViewService, ICustomerViewService
	{
		private readonly ICustomerPartnerService _customerPartnerService;
		private readonly IGetTypeService _getTypeService;
		public CustomerViewService(ICustomerPartnerService customerPartnerService,
			IGetTypeService getTypeService)
		{
			_customerPartnerService = customerPartnerService;
			_getTypeService = getTypeService;
		}

		public async Task<IEnumerable<SelectListItem>> GetCustomerCodeAndNameListItemAsync()
		{
			try
			{
				var channelSelectItems = await _customerPartnerService.GetAll()
					.OrderBy(c => Util.GetValueToSort(c.Code))
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = $"{a.Code} - {a.Customer.Name}",
					}).ToListAsync();
				return channelSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetCustomerCodeListAsync()
		{
			var channelSelectItems = await _customerPartnerService.GetAll()
				.OrderBy(c => Util.GetValueToSort(c.Code))
				.Select(a => new SelectListItem()
				{
					Text = a.Code
				}).ToListAsync();
			return channelSelectItems;
		}

		public async Task<IEnumerable<SelectListItem>> GetCustomerTypeSelectListItemAsync()
		{
			var list = await _getTypeService.GetCustomerTypes()
				.Where(t => t.Id == (int)CustomerTypeEnum.NoPermanent || t.Id == (int)CustomerTypeEnum.Permanent)
				.Select(c => new SelectListItem()
				{
					Value = c.Id.ToString(),
					Text = c.Name,
				}).ToListAsync();
			return list;
		}

		public async Task<IEnumerable<SelectListItem>> GetNonPermamentSelectListItemAsync()
		{
			try
			{
				var channelSelectItems = await _customerPartnerService.GetAll()
					.Where( c => c.Customer.TypeId == (int)CustomerTypeEnum.NoPermanent)
					.OrderBy(c => Util.GetValueToSort(c.Code))
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = $"{a.Code} - {a.Customer.Name}",
					}).ToListAsync();
				return channelSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetPermamentSelectListItemAsync()
		{
			try
			{
				var channelSelectItems = await _customerPartnerService.GetAll()
					.Where(c => c.Customer.TypeId == (int)CustomerTypeEnum.Permanent)
					.OrderBy(c => Util.GetValueToSort(c.Code))
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = $"{a.Code} - {a.Customer.Name}",
					}).ToListAsync();
				return channelSelectItems;

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
				var channelSelectItems = await _customerPartnerService.GetAll()
					.OrderBy(c => Util.GetValueToSort(c.Code))
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Customer.Name
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
