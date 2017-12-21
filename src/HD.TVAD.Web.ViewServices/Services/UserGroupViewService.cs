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
	[Service(ServiceType = typeof(IUserGroupViewService))]
	public class UserGroupViewService : ViewService, IUserGroupViewService
	{
		private readonly IUserGroupService _userGroupService;
		public UserGroupViewService(IUserGroupService userGroupService)
		{
			_userGroupService = userGroupService;
		}
		public async override Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var list = await _userGroupService.GetAll()
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Name,
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
