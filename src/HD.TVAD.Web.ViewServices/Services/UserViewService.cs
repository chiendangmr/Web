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
	[Service(ServiceType = typeof(IUserViewService))]
	public class UserViewService : ViewService, IUserViewService
	{
		private readonly IUserService _userService;
		public UserViewService(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IEnumerable<SelectListItem>> GetEmailListAsync()
		{
			try
			{
				var list = await _userService.GetAll()
					.Select(a => new SelectListItem()
					{
						Text = a.Email,
					}).ToListAsync();

				return list;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetFullNameListAsync()
		{
			try
			{
				var list = await _userService.GetAll()
					.Select(a => new SelectListItem()
					{
						Text = a.FullName,
					}).ToListAsync();

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
				var list = await _userService.GetAll()
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.UserName,
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
