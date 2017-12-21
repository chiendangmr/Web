using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IRateCardCalculation))]
	class FreeRateCard : IRateCardCalculation
	{
		public FreeRateCard()
		{

		}
		public decimal? GetRateCard(SpotBooking booking)
		{
			return 0;
		}
	}
}
