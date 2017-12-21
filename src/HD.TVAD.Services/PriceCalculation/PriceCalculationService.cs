using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
//	[Service(ServiceType = typeof(IPriceCalculationService))]
	class PriceCalculationService : IPriceCalculationService
    {
		private readonly IRateCardCalculationFactory _rateCardCalculationFactory;
		private readonly IPositionCostCalculation _positionCostCalculation;
		private readonly ICustomerDiscountCalculation _customerDiscountCalculation;
		private readonly IAnnexContractDiscountCalculation _annexContractDiscountCalculation;
		private readonly ISponsorProgramDiscountCalculation _sponsorProgramDiscountCalculation;
		private readonly ITimeBandPriceService _timeBandPriceService;
		public PriceCalculationService(IRateCardCalculationFactory rateCardCalculationFactory,
			IPositionCostCalculation positionCostCalculation,
			ICustomerDiscountCalculation customerDiscountCalculation,
			IAnnexContractDiscountCalculation annexContractDiscountCalculation,
			ISponsorProgramDiscountCalculation sponsorProgramDiscountCalculation,
			ITimeBandPriceService timeBandPriceService)
		{
			_rateCardCalculationFactory = rateCardCalculationFactory;
			_positionCostCalculation = positionCostCalculation;
			_customerDiscountCalculation = customerDiscountCalculation;
			_annexContractDiscountCalculation = annexContractDiscountCalculation;
			_sponsorProgramDiscountCalculation = sponsorProgramDiscountCalculation;
			_timeBandPriceService = timeBandPriceService;
		}

		private decimal? GetMaxRateCard(Guid timeBandId)
		{
			try
			{
				var timeBandPrice = _timeBandPriceService.GetAll()
					.Where(t => t.TimeBandId == timeBandId)
					.OrderByDescending(t => t.SpotBlock.Duration)
					.FirstOrDefault();
				if (timeBandPrice != null)
				{
					var rateCard = timeBandPrice.Price;
					return rateCard;
				}
				else
					return null;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public decimal? GetDiscountRate(SpotBooking booking)
		{
			var customerDiscountRate = _customerDiscountCalculation.GetRate(booking);
			var annexContractDiscountRate = _annexContractDiscountCalculation.GetRate(booking);
			var sponsorProgramDiscountRate = _sponsorProgramDiscountCalculation.GetRate(booking);
			var totalRate = customerDiscountRate.GetValueOrDefault(0) + annexContractDiscountRate.GetValueOrDefault(0) + sponsorProgramDiscountRate.GetValueOrDefault(0);

			return totalRate;
		}

		public decimal? GetDiscountValue(SpotBooking booking)
		{
			var customerDiscountRate = _customerDiscountCalculation.GetRate(booking);
			var annexContractDiscountRate = _annexContractDiscountCalculation.GetRate(booking);
			var sponsorProgramDiscountRate = _sponsorProgramDiscountCalculation.GetRate(booking);

			var ratecard = GetRateCard(booking);
			if (ratecard.HasValue)
			{
				var customerDiscountValue = ratecard.Value * customerDiscountRate.Value / 100;
				var annexContractDiscountValue = ratecard.Value * annexContractDiscountRate.Value / 100;
				var sponsorProgramDiscountValue = ratecard.Value * sponsorProgramDiscountRate.Value / 100;

				var totalDiscountValue = customerDiscountValue + annexContractDiscountValue + sponsorProgramDiscountValue; //TODO: more discount type

				return totalDiscountValue;
			}
			return null;
		}

		public decimal? GetPositionCost(SpotBooking booking)
		{
			if (booking.IsPositionCost.HasValue)
			{
				if (booking.IsPositionCost.Value)
				{
					var rate = _positionCostCalculation.GetRate(booking);
					var ratecard = GetMaxRateCard(booking.TimeBandId);
					if (ratecard.HasValue)
					{
						var cost = ratecard * rate / 100;
						return cost;
					}
					else
					{
						return 0;
					}
				}
			}
				return 0;
		}

		public decimal? GetRateCard(SpotBooking booking)
		{
			return _rateCardCalculationFactory.GetRateCardCalculation(booking.PriceType).GetRateCard(booking);
		}

		public decimal? GetTotalAfterDiscount(SpotBooking booking)
		{
			var price = GetRateCard(booking);
			var positionCost = GetPositionCost(booking);
			var discountValue = GetDiscountValue(booking);
			return price.GetValueOrDefault(0) + positionCost.GetValueOrDefault(0) - discountValue.GetValueOrDefault(0);
		}

		public decimal? GetTotalBeforeDiscount(SpotBooking booking)
		{
			var price = GetRateCard(booking);
			var positionCost = GetPositionCost(booking);
			return price.GetValueOrDefault(0) + positionCost.GetValueOrDefault(0);
		}

		public decimal? GetDiscountValue(SpotBooking booking, decimal? cardRate, decimal? positionRate)
		{
			throw new NotImplementedException();
		}
	}
}
