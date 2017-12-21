using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(ISpecialRateCard))]
	class SpecialRateCard : ISpecialRateCard
	{
		private readonly ITimeBandPriceService _timeBandPriceService;
		private readonly IRateSpotBlockService _rateSpotBlockService;
		public SpecialRateCard(ITimeBandPriceService timeBandPriceService,
			IRateSpotBlockService rateSpotBlockService)
		{
			_timeBandPriceService = timeBandPriceService;
			_rateSpotBlockService = rateSpotBlockService;
		}
		public decimal? GetRateCard(SpotBooking booking)
		{
			return booking.AnnexContractAsset.Price;
		}
	}
}
