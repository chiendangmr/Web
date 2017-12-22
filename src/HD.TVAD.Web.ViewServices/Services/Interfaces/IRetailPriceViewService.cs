﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.TVAD.Web.ViewServices
{
	public interface IRetailPriceViewService
	{
		Task<IEnumerable<SelectListItem>> GetRetailTypeSelectListItemAsync();
	}
}