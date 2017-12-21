using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IAnnexContractDiscountCalculation))]
	public class AnnexContractDiscountCalculation : IAnnexContractDiscountCalculation
	{
		private readonly IDiscountAnnexContractService _discountAnnexContractService;
		public AnnexContractDiscountCalculation(IDiscountAnnexContractService discountAnnexContractService)
		{
			_discountAnnexContractService = discountAnnexContractService;
		}
		public decimal? GetRate(SpotBooking booking)
		{
			var discountCustomer = _discountAnnexContractService.GetAll()
				.Where(d => d.AnnexContractId == booking.AnnexContractId)
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
