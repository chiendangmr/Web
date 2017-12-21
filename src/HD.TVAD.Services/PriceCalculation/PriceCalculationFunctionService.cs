using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Dapper;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(IPriceCalculationService))]
	class PriceCalculationFunctionService : IPriceCalculationService
	{
		private IDataContext _context;
		public PriceCalculationFunctionService(IDataContext context)
		{
			_context = context;
		}
		public decimal? GetDiscountRate(SpotBooking booking)
		{
			return 0;
		}

		public decimal? GetDiscountValue(SpotBooking booking,decimal? cardRate, decimal? positionRate)
		{
		//	return 0;
			var __context = _context as DbContext;
			var conn = __context.Database.GetDbConnection();
			var result = conn.Query<decimal?>("SELECT dbo.fn_SpotBookingDiscountRate(@SpotBookingId)",
				new { SpotBookingId = booking.Id}).First();

			return result;
		}

		public decimal? GetDiscountValue(SpotBooking booking)
		{
			//	return 0;
			var __context = _context as DbContext;
			var conn = __context.Database.GetDbConnection();
			var result = conn.Query<decimal?>("SELECT dbo.fn_SpotBookingDiscountRate(@SpotBookingId)",
				new { SpotBookingId = booking.Id }).First();

			return result;
		}

		public decimal? GetPositionCost(SpotBooking booking)
		{
			var __context = _context as DbContext;
			var conn = __context.Database.GetDbConnection();
			var result = conn.Query<decimal?>("SELECT dbo.fn_SpotBookingPositionRate(@SpotBookingId)", new { SpotBookingId = booking.Id }).First();

			return result;
		}

		public decimal? GetRateCard(SpotBooking booking)
		{
			//var __context = _context as DbContext;
			//var spotBookingCardRate = new SqlParameter() {
			//	DbType = System.Data.DbType.Decimal,
			//	Direction = System.Data.ParameterDirection.Output,
			//	ParameterName = "@SpotBookingCardRate",
			//};
			//__context.Database.ExecuteSqlCommand("EXEC [Price].[CalculationSpotBookingCardRate] @SpotBookingId, @SpotBookingCardRate OUTPUT",
			//	new SqlParameter("@SpotBookingId", booking.Id),
			//	spotBookingCardRate);

			//var result = spotBookingCardRate.Value;

			//return (decimal)result;

			var __context = _context as DbContext;
			var conn = __context.Database.GetDbConnection();
			var result = conn.Query<decimal?>("SELECT dbo.fn_SpotBookingCardRate(@SpotBookingId)", new { SpotBookingId = booking.Id }).First();

			return result;
		}

		public decimal? GetTotalAfterDiscount(SpotBooking booking)
		{
			//var rateCard = GetRateCard(booking);
			//var positionCost = GetPositionCost(booking);
			//var discountValue = GetDiscountValue(booking);

			var rateCard = booking.CardRateCalc;
			var positionCost = booking.PositionRateCalc;
			var discountValue = booking.DiscountRateCalc;

			var result = rateCard.GetValueOrDefault() + positionCost.GetValueOrDefault() - discountValue.GetValueOrDefault();
			return result;
		}

		public decimal? GetTotalBeforeDiscount(SpotBooking booking)
		{
			var rateCard = GetRateCard(booking);
			var positionCost = GetPositionCost(booking);
			var result = rateCard.GetValueOrDefault() + positionCost.GetValueOrDefault();
			return result;
		}
	}
}
