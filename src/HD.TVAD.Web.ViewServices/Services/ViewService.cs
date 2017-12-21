using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.ViewServices
{
	public abstract class ViewService : IViewService
	{
		public ViewService()
		{

		}
		public async Task<IEnumerable<SelectListItem>> GetNameListAsync()
		{
			var list = (await GetSelectListItemAsync())
				.Select(a => new SelectListItem()
				{
					Text = a.Text
				});
			return list;
		}

		public abstract Task<IEnumerable<SelectListItem>> GetSelectListItemAsync();
	}
}
