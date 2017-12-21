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
	[Service(ServiceType = typeof(IContentViewService))]
	public class ContentViewService : ViewService, IContentViewService
	{
		private readonly IContentService _channelService;
		public ContentViewService(IContentService channelService)
		{
			_channelService = channelService;
		}

		public Task<IEnumerable<SelectListItem>> GetAssetCodeListAsync()
		{
			return GetSelectListItemAsync();
		}

		public async Task<IEnumerable<SelectListItem>> GetProductNameListAsync()
		{
			try
			{
				var channelSelectItems = await _channelService.GetAll()
					.OrderBy(c => c.ProductName)
					.Select(a => new SelectListItem()
					{
						Text = a.ProductName
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
				var channelSelectItems = await _channelService.GetAll()
					.OrderBy(c => c.Code)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Code
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
