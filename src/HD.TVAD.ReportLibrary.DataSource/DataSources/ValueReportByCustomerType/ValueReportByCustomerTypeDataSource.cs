using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportByCustomerType
{
	public class ValueReportByCustomerTypeDataSource : DataSourceCalculationPrice<ValueReportByCustomerTypeViewModel>
	{
		public ValueReportByCustomerTypeDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService, 
			ValueReportByCustomerTypeParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<ValueReportByCustomerTypeParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			switch (parameter.BookingTypeAndCustomerType)
			{
				case 1:
					foreach (var spot in spots)
					{
						foreach (var spotBooking in spot.SpotBookings
							.Where(s => parameter.IsApproved ? s.IsApproved : true)
							.Where(s => s.IsNormalBooking)
							.Where(s => s.CustomerType == ApplicationCore.Entities.ContractSchema.CustomerTypeEnum.NoPermanent))
						{
							Data.Add(new ValueReportByCustomerTypeViewModel()
							{
								TimeBandName = spot.TimeBandName,
								CustomerCode = spotBooking.CustomerCode,
								CustomerName = spotBooking.CustomerName,
								BookingTypeName = spotBooking.AnnexContractAsset.AnnexContract.BookingType.Description,
								DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
								Price = _priceCalculationService.GetRateCard(spotBooking),
							});
						}
					}
					break;
				case 2:

					foreach (var spot in spots)
					{
						foreach (var spotBooking in spot.SpotBookings
							.Where(s => parameter.IsApproved ? s.IsApproved : true)
							.Where(s => s.IsRetailBooking))
						{
							Data.Add(new ValueReportByCustomerTypeViewModel()
							{
								TimeBandName = spot.TimeBandName,
								CustomerCode = spotBooking.CustomerCode,
								CustomerName = spotBooking.CustomerName,
								BookingTypeName = spotBooking.AnnexContractAsset.AnnexContract.BookingType.Description,
								DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
								Price = _priceCalculationService.GetRateCard(spotBooking),
							});
						}
					}
					break;
				default:

					foreach (var spot in spots)
					{
						foreach (var spotBooking in spot.SpotBookings
							.Where(s => parameter.IsApproved ? s.IsApproved : true)
							.Where(s => s.IsNormalBooking)
							.Where(s => s.CustomerType == ApplicationCore.Entities.ContractSchema.CustomerTypeEnum.Permanent))
						{
							Data.Add(new ValueReportByCustomerTypeViewModel()
							{
								TimeBandName = spot.TimeBandName,
								CustomerCode = spotBooking.CustomerCode,
								CustomerName = spotBooking.CustomerName,
								BookingTypeName = spotBooking.AnnexContractAsset.AnnexContract.BookingType.Description,
								DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
								Price = _priceCalculationService.GetRateCard(spotBooking),
							});
						}
					}
					break;
			}
		}
	}
}
