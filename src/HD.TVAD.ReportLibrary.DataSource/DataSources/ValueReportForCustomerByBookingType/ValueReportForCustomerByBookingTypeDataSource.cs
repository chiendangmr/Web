using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportForCustomerByBookingType
{
	public class ValueReportForCustomerByBookingTypeDataSource : DataSource<ValueReportForCustomerByBookingTypeViewModel>
	{
		public ValueReportForCustomerByBookingTypeDataSource(IServiceProvider serviceProvider, ValueReportForCustomerByBookingTypeParameter parameter)
		{
			var parameterHelper = new ParameterHelper<ValueReportForCustomerByBookingTypeParameter>(parameter);

			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var priceCalculationService = serviceProvider.GetService(typeof(IPriceCalculationService)) as IPriceCalculationService;

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();


			var spotBookings = spots.SelectMany(s => s.SpotBookings)
					.Where(s => parameter.IsApproved ? s.IsApproved : true)
					.Where(s => parameter.CustomerId.HasValue ? s.CustomerId == parameter.CustomerId : true);
				//	.Where(s => s.AnnexContractAsset.AnnexContract.Customer.IsPartnerCustomer);


			foreach (var spotBooking in spotBookings)
			{
				var totalValueBooking = 0M;
				var totalValueRetail = 0M;
				var totalValueSponsor = 0M;

				if (spotBooking.IsRetailBooking)
					totalValueRetail = priceCalculationService.GetTotalAfterDiscount(spotBooking).GetValueOrDefault();

				if (spotBooking.IsNormalContractBooking)
					totalValueBooking = priceCalculationService.GetTotalAfterDiscount(spotBooking).GetValueOrDefault();

				if (spotBooking.IsInProgramBooking || spotBooking.IsOutProgramBooking)
					totalValueSponsor = priceCalculationService.GetTotalAfterDiscount(spotBooking).GetValueOrDefault();

				Data.Add(new ValueReportForCustomerByBookingTypeViewModel()
				{
					CustomerCode = spotBooking.CustomerCode,
					CustomerName = spotBooking.CustomerName,
					ContractCode = spotBooking.ContractCode,
					TotalValueBooking = totalValueBooking,
					TotalValueRetail = totalValueRetail,
					TotalValueSponsor = totalValueSponsor,
				});
			}
		}
	}
}
