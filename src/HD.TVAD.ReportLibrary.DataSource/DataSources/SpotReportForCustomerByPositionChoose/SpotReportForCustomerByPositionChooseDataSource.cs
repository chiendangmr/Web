using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForCustomerByPositionChoose
{
	public class SpotReportForCustomerByPositionChooseDataSource : DataSource<SpotReportForCustomerByPositionChooseViewModel>
	{
		public SpotReportForCustomerByPositionChooseDataSource(IServiceProvider serviceProvider, SpotReportForCustomerByPositionChooseParameter parameter)
		{
			var parameterHelper = new ParameterHelper<SpotReportForCustomerByPositionChooseParameter>(parameter);

			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var priceCalculationService = serviceProvider.GetService(typeof(IPriceCalculationService)) as IPriceCalculationService;

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			var spotBookings = spots.SelectMany(s => s.SpotBookings)
					.Where(s => s.IsNormalBooking)
					.Where(s => parameter.CustomerId.HasValue ? s.CustomerId == parameter.CustomerId : true)
					.ToList();

			while (spotBookings.Count > 0)
			{
				var firstBooking = spotBookings[0];
				   var firstBookingViewModel = new SpotReportForCustomerByPositionChooseViewModel()
				   {
					   AnnexContractCode = firstBooking.ContractCode,
					   AssetCode = firstBooking.AssetCode,
					   ProductName = firstBooking.ProducerName,
					   TimeBandName = firstBooking.Spot.TimeBandName,
					   Price = priceCalculationService.GetRateCard(firstBooking),
					   DiscountRate = priceCalculationService.GetDiscountRate(firstBooking),
					   AssetDuration = firstBooking.AssetDuration,

				   };
				var sampleBookings = spotBookings.Where(s =>
					s.ContractCode == firstBooking.ContractCode &&
					s.AssetCode == firstBooking.AssetCode &&
					s.Spot.TimeBandName == firstBooking.Spot.TimeBandName &&
					priceCalculationService.GetRateCard(s) == priceCalculationService.GetRateCard(firstBooking) &&
					priceCalculationService.GetDiscountRate(s) == priceCalculationService.GetDiscountRate(firstBooking)
				).ToList();

				var choosePositionBookings = sampleBookings.Where(s =>
					s.IsPositionCost.HasValue ? s.IsPositionCost.Value : false
				).ToList();
				var dayHasPositionChoose = "";
				if (choosePositionBookings.Count == 1)
					dayHasPositionChoose = choosePositionBookings.First().Spot.BroadcastDate.Day.ToString();

				if (choosePositionBookings.Count > 1)
					dayHasPositionChoose = choosePositionBookings.Select(s => s.Spot.BroadcastDate.Day.ToString())
						.Aggregate((a, b) => a + ',' + b);

				var positionCost = choosePositionBookings.Sum(s => priceCalculationService.GetPositionCost(s));

				Data.Add(new SpotReportForCustomerByPositionChooseViewModel()
				{
					AnnexContractCode = firstBookingViewModel.AnnexContractCode,
					AssetCode = firstBookingViewModel.AssetCode,
					ProductName = firstBookingViewModel.ProductName,
					AssetDuration = firstBookingViewModel.AssetDuration,
					TimeBandName = firstBookingViewModel.TimeBandName,
					DayHasPositionChoose = dayHasPositionChoose,
					PositionChooseCount = choosePositionBookings.Count,
					SpotCount = sampleBookings.Count,
					DiscountRate = firstBookingViewModel.DiscountRate,
					PositionCost = positionCost,
					Price = firstBookingViewModel.Price,

				});
				foreach (var booking in sampleBookings) 
				{
					spotBookings.Remove(booking); // clean
				}
			}
		}
	}
}
