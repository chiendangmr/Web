using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportByChannel
{
	public class ValueReportByChannelDataSource : DataSourceCalculationPrice<ValueReportByChannelViewModel>
	{
		public ValueReportByChannelDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			ValueReportByChannelParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<ValueReportByChannelParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();
			
			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved? s.IsApproved: true))
				{
					Data.Add(new ValueReportByChannelViewModel()
					{
						ChannelName = spot.ChannelName,
						BookingTypeName = spotBooking.AnnexContractAsset.AnnexContract.BookingType.Description,
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),						
					});
				}
			}
		}
	}
}
