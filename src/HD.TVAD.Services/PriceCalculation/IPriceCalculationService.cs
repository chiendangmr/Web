using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Services.PriceCalculation
{
    public interface IPriceCalculationService
    {
		decimal? GetRateCard(SpotBooking booking);
		decimal? GetPositionCost(SpotBooking booking);
		decimal? GetDiscountValue(SpotBooking booking);
		decimal? GetDiscountValue(SpotBooking booking, decimal? cardRate, decimal? positionRate);
		decimal? GetDiscountRate(SpotBooking booking);
		decimal? GetTotalAfterDiscount(SpotBooking booking);
		decimal? GetTotalBeforeDiscount(SpotBooking booking);
	}
}
