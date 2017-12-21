using HD.Station;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IPositionCostCalculation))]
	public class PositionCostCalculation : IPositionCostCalculation
	{
		private readonly IPositionRateService _positionRateService;
		public PositionCostCalculation(IPositionRateService positionRateService)
		{
			_positionRateService = positionRateService;
		}
		public decimal? GetCost(SpotBooking booking)
		{
			throw new NotImplementedException();
		}
		public decimal? GetRate(SpotBooking booking) {

			var positionRate = _positionRateService.GetAll()
				.Where(a => a.TimeBandId == booking.TimeBandId)
				.FirstOrDefault();
			if (positionRate != null)
			{
				return positionRate.Rate;
			}
			else
			{
				var positionRateGeneral = _positionRateService.GetAll()
				   .Where(a => a.TimeBand == null) // ti le chung
				   .FirstOrDefault();
				if (positionRateGeneral !=null)
				{
					return positionRateGeneral.Rate;
				}
				else
				{
					throw new Exception("Not have any rate");
				}
			}
		}
	}
}
