using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HD.TVAD.Web.ViewServices
{
	public interface ISpotBlockViewService : IViewService
	{
		IEnumerable<SelectListItem> GetDurationList();
	}
}
