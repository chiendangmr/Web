using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportForCustomerByProductGroup
{
	public class ValueReportForCustomerByProductGroupDataSource : DataSourceCalculationPrice<ValueReportForCustomerByProductGroupViewModel>
	{
		public ValueReportForCustomerByProductGroupDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			ValueReportForCustomerByProductGroupParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<ValueReportForCustomerByProductGroupParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => s.IsNormalBooking)
					.Where(s => s.HasSponsorProgram))
				{
					Data.Add(new ValueReportForCustomerByProductGroupViewModel() {
						AssetCode = spotBooking.AssetCode,
						ProducerName = spotBooking.ProducerName,
						ProductName = spotBooking.AnnexContractAsset.Content.ProductName,
						ProductGroupName = spotBooking.ProductGroupName,
						AssetDuration = spotBooking.AssetDuration,
						CustomerName = spotBooking.CustomerName,
						CustomerCode = spotBooking.CustomerCode,
						Price = _priceCalculationService.GetTotalBeforeDiscount(spotBooking),
						TotalValue = _priceCalculationService.GetTotalAfterDiscount(spotBooking)
					});
				}
			}
		}
	}
}
