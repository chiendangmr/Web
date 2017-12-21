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
	[Service(ServiceType = typeof(IRegisterViewService))]
	public class RegisterViewService : ViewService, IRegisterViewService
	{
		private readonly IRegisterService _registerService;
		public RegisterViewService(IRegisterService registerService)
		{
			_registerService = registerService;
		}
		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var registerSelectItems = await _registerService.GetAll()
					.OrderBy(c => c.Name)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Name
					}).ToListAsync();
				return registerSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
