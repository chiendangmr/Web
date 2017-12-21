using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Price;
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
	[Service(ServiceType = typeof(IDateTimeReportViewService))]
	public class DateTimeReportViewService : IDateTimeReportViewService
	{
		public DateTimeReportViewService()
		{

		}

		public IEnumerable<SelectListItem> GetMonthSelectListItem()
		{

			var monthSelectItems = new List<SelectListItem>();
			for (int i = 1; i <= 12; i++)
			{
				monthSelectItems.Add(new SelectListItem()
				{
					Text = i.ToString(),
					Value = i.ToString(),
				});
			}
			return monthSelectItems;
		}

		public IEnumerable<SelectListItem> GetThreeMonthSelectListItem()
		{
			var threeMonthSelectItems = new List<SelectListItem>();
			for (int i = 1; i <= 4; i++)
			{
				threeMonthSelectItems.Add(new SelectListItem()
				{
					Text = i.ToString(),
					Value = i.ToString(),
				});
			}
			return threeMonthSelectItems;
		}

		public IEnumerable<SelectListItem> GetYearSelectListItem()
		{
			var yearSelectItems = new List<SelectListItem>();
			for (int i = 2016; i < 2020; i++)
			{
				yearSelectItems.Add(new SelectListItem()
				{
					Text = i.ToString(),
					Value = i.ToString(),
				});
			}
			return yearSelectItems;
		}
	}
}
