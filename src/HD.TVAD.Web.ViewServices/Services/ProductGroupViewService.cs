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
	[Service(ServiceType = typeof(IProductGroupViewService))]
	public class ProductGroupViewService : ViewService, IProductGroupViewService
	{
		private readonly IProductGroupService _productGroupService;
		public ProductGroupViewService(IProductGroupService productGroupService)
		{
			_productGroupService = productGroupService;
		}
		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var productGroupSelectItems = await _productGroupService.GetAll()
					.OrderBy(c => c.Name)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Name
					}).ToListAsync();
				return productGroupSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
