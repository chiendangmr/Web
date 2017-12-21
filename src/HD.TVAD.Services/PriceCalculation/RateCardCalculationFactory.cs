using HD.Station;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Price;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IRateCardCalculationFactory))]
	public class RateCardCalculationFactory : IRateCardCalculationFactory
	{
		private readonly ITimeBandPriceService _timeBandPriceService;
		private readonly ICeilingRateCard _ceilingRateCard;
		private readonly IRateBlockRateCard _rateBlockRateCard;
		private readonly IRateByOneBlockRateCard _rateByOneBlockRateCard;
		private readonly IRetailPriceRateCard _retailPriceRateCard;
		private readonly IBenefitRateCard _benefitRateCard;
		private readonly ISpecialRateCard _specialRateCard;
		public RateCardCalculationFactory(ITimeBandPriceService timeBandPriceService,
			ICeilingRateCard ceilingRateCard,
			IRateBlockRateCard rateBlockRateCard,
			IRateByOneBlockRateCard rateByOneBlockRateCard,
			IRetailPriceRateCard retailPriceRateCard,
			IBenefitRateCard benefitRateCard,
			ISpecialRateCard specialRateCard)
		{
			_timeBandPriceService = timeBandPriceService;
			_ceilingRateCard = ceilingRateCard;
			_rateBlockRateCard = rateBlockRateCard;
			_rateByOneBlockRateCard = rateByOneBlockRateCard;
			_retailPriceRateCard = retailPriceRateCard;
			_benefitRateCard = benefitRateCard;
			_specialRateCard = specialRateCard;
		}
		public IRateCardCalculation GetRateCardCalculation(PriceTypeEnum priceType)
		{
			switch (priceType)
			{
				case PriceTypeEnum.Free:
					return new FreeRateCard();
				case PriceTypeEnum.Ceiling:
					return _ceilingRateCard;
				case PriceTypeEnum.Rate:
					return _rateBlockRateCard;
				case PriceTypeEnum.RateByBlock:
					return _rateByOneBlockRateCard;
				case PriceTypeEnum.Retail:
					return _retailPriceRateCard;
				case PriceTypeEnum.Benefit:
					return _benefitRateCard;
				case PriceTypeEnum.Special:
					return _specialRateCard;
				default:
					throw new NotImplementedException();
			}
		}
	}
}
