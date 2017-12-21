using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(ICeilingRateCard))]
	class CeilingRateCard : ICeilingRateCard
	{
		private readonly ITimeBandPriceService _timeBandPriceService;
		public CeilingRateCard(ITimeBandPriceService timeBandPriceService)
		{
			_timeBandPriceService = timeBandPriceService;
		}
		public decimal? GetRateCard(SpotBooking booking)
		{
			var timeBandPrice = _timeBandPriceService.GetAll()
				.Where(t => t.TimeBandId == booking.TimeBandId)
				.Where(t => t.SpotBlock.Duration >= booking.AssetDuration)
				.OrderBy(t => t.SpotBlock.Duration)
				.FirstOrDefault();
			if (timeBandPrice != null)
			{
				return timeBandPrice.Price;
			}
			else
			{
				//	throw new InvalidOperationException();
				return null;
			}
		}
	}
}
