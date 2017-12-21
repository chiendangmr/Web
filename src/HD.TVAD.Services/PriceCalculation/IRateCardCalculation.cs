using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Services.PriceCalculation
{
    public interface IRateCardCalculation
    {
		decimal? GetRateCard(SpotBooking booking);
    }
}
