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
	[Service(ServiceType = typeof(ISponsorProgramViewService))]
	public class SponsorProgramViewService : ViewService, ISponsorProgramViewService
	{
		private readonly ISponsorProgramService _sponsorProgramService;
		private readonly IGetTypeService _getTypeService;
		public SponsorProgramViewService(ISponsorProgramService sponsorProgramService,
			IGetTypeService getTypeService)
		{
			_sponsorProgramService = sponsorProgramService;
			_getTypeService = getTypeService;
		}

		public async Task<IEnumerable<SelectListItem>> GetCodeAndNameSelectListItemAsync()
		{
			try
			{
				var list = await _sponsorProgramService.GetAll()
					.OrderBy(c => Util.GetValueToSort(c.Code))
					.Select(c => new SelectListItem()
					{
						Value = c.Id.ToString(),
						Text = $"{c.Code} - {c.Name} - {c.AnnexContractType.Name}",
					}).ToListAsync();
				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetCodeListAsync()
		{
			try
			{
				var list = await _sponsorProgramService.GetAll()
					.OrderBy(c => Util.GetValueToSort(c.Code))
					.Select(a => new SelectListItem()
					{
						Text = a.Code
					}).ToListAsync();
				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetContractTypeSelectListItemAsync()
		{
			var defaultContractTypeSelectItems = await _getTypeService.GetAnnexContractTypes()
				.Select(c => new SelectListItem()
			{
				Value = c.Id.ToString(),
				Text = c.Name,
			}).ToListAsync();
			return defaultContractTypeSelectItems;
		}

		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var list = await _sponsorProgramService.GetAll()
					.OrderBy(c => Util.GetValueToSort(c.Code))
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Name
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
