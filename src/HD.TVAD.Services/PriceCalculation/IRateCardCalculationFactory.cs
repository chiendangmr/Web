using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Price;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Services.PriceCalculation
{
    interface IRateCardCalculationFactory
	{
		IRateCardCalculation GetRateCardCalculation(PriceTypeEnum priceType);
    }
}
