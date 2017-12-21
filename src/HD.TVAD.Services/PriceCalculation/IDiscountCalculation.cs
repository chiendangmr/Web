using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Services.PriceCalculation
{
    interface IDiscountCalculation
    {
		decimal? GetRate(SpotBooking booking);
    }
}
