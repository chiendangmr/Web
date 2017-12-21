using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IRateBlockRateCard))]
	class RateBlockRateCard : IRateBlockRateCard
	{
		private readonly ITimeBandPriceService _timeBandPriceService;
		private readonly IRateSpotBlockService _rateSpotBlockService;
		private readonly ISpotBlockRateService _spotBlockRateService;
		public RateBlockRateCard(ITimeBandPriceService timeBandPriceService,
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
				if (rate.HasValue)
				{
					var durationOfRate = rateSpotBlock.SpotBlock.Duration;

					var rateCardOfThisDuration = _timeBandPriceService.GetRateOfBlock(booking.TimeBandId, rateSpotBlock.SpotBlockId);

					var calculatedRateCard = rateCardOfThisDuration.Value * (rate / 100) * booking.AssetDuration / durationOfRate;

					return calculatedRateCard;

				}
				else
				{
					var spotBlockRate = _spotBlockRateService.GetAll()
						.Where(r => r.SpotBlockId == rateSpotBlock.SpotBlockId)
						.FirstOrDefault();
					if (spotBlockRate != null)
					{
						var _rate = spotBlockRate.Rate;
						var rateCardOfThisDuration = _timeBandPriceService.GetRateOfBlock(booking.TimeBandId, rateSpotBlock.SpotBlockId);

						var calculatedRateCard = rateCardOfThisDuration.Value * (_rate / 100);

						return calculatedRateCard;

					}
					else
					{
						return 0;
					}
				}
			}
			else
			{
				return 0;
			}
		}
	}
}
