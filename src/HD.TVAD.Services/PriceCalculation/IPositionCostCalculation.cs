using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Services.PriceCalculation
{
    public interface IPositionCostCalculation
    {
		decimal? GetCost(SpotBooking booking);
		decimal? GetRate(SpotBooking booking);
	}
}
