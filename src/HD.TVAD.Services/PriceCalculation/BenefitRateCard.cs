using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IBenefitRateCard))]
	class BenefitRateCard : IBenefitRateCard
	{
		private readonly ITimeBandPriceService _timeBandPriceService;
		private readonly IRateSpotBlockService _rateSpotBlockService;
		private readonly IBenefitPriceService _benefitPriceService;
		public BenefitRateCard(ITimeBandPriceService timeBandPriceService,
			IRateSpotBlockService rateSpotBlockService,
			IBenefitPriceService benefitPriceService)
		{
			_timeBandPriceService = timeBandPriceService;
			_rateSpotBlockService = rateSpotBlockService;
			_benefitPriceService = benefitPriceService;
		}
		public decimal? GetRateCard(SpotBooking booking)
		{
			var benefitPrice = _benefitPriceService.GetAll()
				.Where(r => r.BenefitTypeId == booking.PriceTypeDetailId)
				.Where(r => r.BenefitPriceTimeBands.Any( t => t.TimeBandId == booking.TimeBandId))
				.Where(r => r.BenefitPriceSponsorPrograms.Any( s => s.SponsorProgramId == booking.SponsorProgramId))
				.FirstOrDefault();

			if (benefitPrice != null)
			{
				var price = benefitPrice.Price;

				return price;
			}
			else
			{
				return 0;
			}
		}
	}
}
