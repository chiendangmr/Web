using HD.Station;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(ICustomerDiscountCalculation))]
	public class CustomerDiscountCalculation : ICustomerDiscountCalculation
	{
		private readonly IDiscountCustomerService _discountCustomerService;
		public CustomerDiscountCalculation(IDiscountCustomerService discountCustomerService)
		{
			_discountCustomerService = discountCustomerService;
		}
		public decimal? GetRate(SpotBooking booking)
		{
			var discountCustomer = _discountCustomerService.GetAll()
				.Where(d => d.CustomerId == booking.CustomerId)
				.FirstOrDefault();
			if (discountCustomer != null)
			{
				return discountCustomer.Rate;
			}
			else
			{
				return 0;
			}
		}
	}
}
