using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IRateByOneBlockRateCard))]
	class RateByOneBlockRateCard : IRateByOneBlockRateCard
	{
		private readonly ITimeBandPriceService _timeBandPriceService;
		private readonly IRateSpotBlockService _rateSpotBlockService;
		private readonly ISpotBlockRateService _spotBlockRateService;
		public RateByOneBlockRateCard(ITimeBandPriceService timeBandPriceService,
			IRateSpotBlockService rateSpotBlockService,
			ISpotBlockRateService spotBlockRateService)
		{
			_timeBandPriceService = timeBandPriceService;
			_rateSpotBlockService = rateSpotBlockService;
			_spotBlockRateService = spotBlockRateService;
		}
		public decimal? GetRateCard(SpotBooking booking)
		{
			var rateSpotBlock = _rateSpotBlockService.GetAll()
				.Where(r => r.Id == booking.PriceTypeDetailId)
				.FirstOrDefault();

			if (rateSpotBlock != null)
			{
				var rate = rateSpotBlock.Rate;
				var durationOfRate = rateSpotBlock.SpotBlock.Duration;

				var rateCardOfThisDuration = _timeBandPriceService.GetRateOfBlock(booking.TimeBandId, rateSpotBlock.SpotBlockId);

				var calculatedRateCard = rateCardOfThisDuration * (rate / 100); // main formula

				return calculatedRateCard;
			}
			else
			{
				return 0;
			}
		}
	}
}
