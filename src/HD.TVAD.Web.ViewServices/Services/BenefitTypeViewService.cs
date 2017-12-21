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
	[Service(ServiceType = typeof(IBenefitTypeViewService))]
	public class BenefitTypeViewService : ViewService, IBenefitTypeViewService
	{
		private readonly IBenefitTypeService _benefitTypeService;
		public BenefitTypeViewService(IBenefitTypeService benefitTypeService)
		{
			_benefitTypeService = benefitTypeService;
		}
		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var benefitTypeSelectItems = await _benefitTypeService.GetAll()
					.OrderBy(c => c.Code)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Code,
					}).ToListAsync();
				return benefitTypeSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
