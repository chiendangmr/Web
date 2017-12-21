using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.BroadcastCertificate;
using HD.TVAD.ReportLibrary.BroadcastCertificateWithValueContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.Services.PriceCalculation;

namespace HD.TVAD.ReportLibrary.SpotValueOfContract
{
    public class SpotValueOfContractDataSource : DataSource<SpotValueOfContractViewModel>
    {
		public SpotValueOfContractDataSource(IServiceProvider serviceProvider,
			SpotValueOfContractParameter parameter)			
		{

			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var _spotBookingService = serviceProvider.GetService(typeof(ISpotBookingService)) as ISpotBookingService;
			var _priceCalculationService = serviceProvider.GetService(typeof(IPriceCalculationService)) as IPriceCalculationService;

			var _spotBookings = _spotBookingService.GetAll()
				.Where(s => parameter.IsAllTime ? true : s.Spot.BroadcastDate >= parameter.FromDate && s.Spot.BroadcastDate <= parameter.ToDate)
				.Where(s => parameter.AnnexContractId.Equals(Guid.Empty) ? true
						: s.AnnexContractAsset.AnnexContractId == parameter.AnnexContractId)
				.Where(s => parameter.AnnexContractAssetId.Equals(Guid.Empty) ? true
						: s.AnnexContractAssetId == parameter.AnnexContractAssetId)
				.ToList();

			var spotBookings = _spotBookings;
			//	.Where(s => s.IsApproved);

			foreach (var spotBooking in spotBookings)
				{
					Data.Add(new SpotValueOfContractViewModel() {
						AssetCode = spotBooking.AssetCode,
						TimeBandName = spotBooking.Spot.TimeBandName,
						Duration = spotBooking.AssetDuration,
						SpotBlockDuration = 30,
						DiscountRate = _priceCalculationService.GetDiscountRate(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),
						PositionCost = _priceCalculationService.GetPositionCost(spotBooking),
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						Group = 1,
						RateCard = 20,					
					});
				}
			
		}
    }
}
