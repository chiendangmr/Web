using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportForCustomerByChannel
{
	public class ValueReportForCustomerByChannelDataSource : DataSourceCalculationPrice<ValueReportForCustomerByChannelViewModel>
	{
		public ValueReportForCustomerByChannelDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			ValueReportForCustomerByChannelParameter parameter)
			: base(priceCalculationService)
		{

			var parameterHelper = new ParameterHelper<ValueReportForCustomerByChannelParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true)
					.Where(s => s.CustomerId == parameter.CustomerId.Value)
					.Where(s => s.AnnexContractAsset.AnnexContract.Customer.CustomerPartners != null)
					.Where(s => s.AnnexContractAsset.AnnexContract.AnnexContractPartners != null))
				{
					Data.Add(new ValueReportForCustomerByChannelViewModel()
					{
						ProductName = spotBooking.AnnexContractAsset.Content.ProductName,
						ChannelName = spot.TimeBandSlice.TimeBand.TimeBandBase.Parent.Name,
						DiscountRate = _priceCalculationService.GetDiscountRate(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),
						PositionCost = _priceCalculationService.GetPositionCost(spotBooking),
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
					});
				}

			}
		}
	}
}
