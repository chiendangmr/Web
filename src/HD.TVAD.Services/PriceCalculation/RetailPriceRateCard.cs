using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IRetailPriceRateCard))]
	class RetailPriceRateCard : IRetailPriceRateCard
	{
		private readonly ITimeBandPriceService _timeBandPriceService;
		private readonly IRateSpotBlockService _rateSpotBlockService;
		private readonly IRetailPriceService _retailPriceService;
		public RetailPriceRateCard(ITimeBandPriceService timeBandPriceService,
			IRateSpotBlockService rateSpotBlockService,
			IRetailPriceService retailPriceService)
		{
			_timeBandPriceService = timeBandPriceService;
			_rateSpotBlockService = rateSpotBlockService;
			_retailPriceService = retailPriceService;
		}
		public decimal? GetRateCard(SpotBooking booking)
		{
			var retailPrice = _retailPriceService.GetAll()
				.Where(r => r.RetailTypeId == booking.PriceTypeDetailId)
				.FirstOrDefault();

			if (retailPrice != null)
			{
				var price = retailPrice.Price;

				return price;
			}
			else
			{
				return 0;
			}
		}
	}
}
