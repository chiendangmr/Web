using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.TVAD.Web.ViewServices
{
	public interface ICustomerViewService : IViewService
	{
		Task<IEnumerable<SelectListItem>> GetCustomerTypeSelectListItemAsync();
		Task<IEnumerable<SelectListItem>> GetCustomerCodeAndNameListItemAsync();
		Task<IEnumerable<SelectListItem>> GetCustomerCodeListAsync();
		Task<IEnumerable<SelectListItem>> GetNonPermamentSelectListItemAsync();
		Task<IEnumerable<SelectListItem>> GetPermamentSelectListItemAsync();
	}
}
