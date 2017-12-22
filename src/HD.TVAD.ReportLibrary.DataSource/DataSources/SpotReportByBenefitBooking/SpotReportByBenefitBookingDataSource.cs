﻿using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByBenefitBooking
{
	public class SpotReportByBenefitBookingDataSource : DataSourceCalculationPrice<SpotReportByBenefitBookingViewModel>
	{
		public SpotReportByBenefitBookingDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			SpotReportByBenefitBookingParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<SpotReportByBenefitBookingParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();
			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true)
					.Where(s => s.IsNormalBooking)
					.Where(s => s.HasSponsorProgram)
					.Where(s => s.AnnexContractAsset.AnnexContract.BookingTypeId == (int)BookingTypeEnum.Contract_Sponsor_Benefit))   // benefit
				{
					Data.Add(new SpotReportByBenefitBookingViewModel()
					{
						CustomerCode = spotBooking.CustomerCode,
						SponsorProgramName = spotBooking.SponsorProgramName,						
						SponsorProgramCode = spotBooking.SponsorProgramCode,
						CustomerName = spotBooking.CustomerName,
						ContractCode = spotBooking.ContractCode,
						AssetDuration = spotBooking.AssetDuration,
						PositionCost = _priceCalculationService.GetPositionCost(spotBooking),
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),
					});
				}

			}
		}
	}
}