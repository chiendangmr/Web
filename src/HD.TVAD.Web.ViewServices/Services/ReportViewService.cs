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
	[Service(ServiceType = typeof(IReportViewService))]
	public class ReportViewService : IReportViewService
	{
		public ReportViewService()
		{

		}

		public IEnumerable<SelectListItem> GetAssetDurationTypeSelectListItem()
		{
			var assetDurationTypeSelectItems = new List<SelectListItem>();
			assetDurationTypeSelectItems.Add(new SelectListItem()
			{
				Text = "All",
				Value = "0",
			});
			assetDurationTypeSelectItems.Add(new SelectListItem()
			{
				Text = "< 10s",
				Value = "1",
			});
			assetDurationTypeSelectItems.Add(new SelectListItem()
			{
				Text = "10 - 15s",
				Value = "2",
			});
			return assetDurationTypeSelectItems;
		}

		public IEnumerable<SelectListItem> GetCustomerTypeSelectListItem()
		{
			var bookingTypeAndCustomerTypeSelectItems = new List<SelectListItem>();

			bookingTypeAndCustomerTypeSelectItems.Add(new SelectListItem()
			{
				Text = "Permament",
				Value = "0",
			});
			bookingTypeAndCustomerTypeSelectItems.Add(new SelectListItem()
			{
				Text = "Not Permament",
				Value = "1",
			});
			bookingTypeAndCustomerTypeSelectItems.Add(new SelectListItem()
			{
				Text = "Retail",
				Value = "2",
			});
			return bookingTypeAndCustomerTypeSelectItems;
		}

		public IEnumerable<SelectListItem> GetFreeOrNotTypeSelectListItem()
		{
			var typeSelectItems = new List<SelectListItem>();
			typeSelectItems.Add(new SelectListItem()
			{
				Text = "All",
				Value = "0",
			});
			typeSelectItems.Add(new SelectListItem()
			{
				Text = "Free",
				Value = "1",
			});
			typeSelectItems.Add(new SelectListItem()
			{
				Text = "NotFree",
				Value = "2",
			});
			return typeSelectItems;
		}
	}
}
