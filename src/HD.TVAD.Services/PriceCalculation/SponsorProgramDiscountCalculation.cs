using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.Station;
using HD.TVAD.Web.Services;
using System.Linq;

namespace HD.TVAD.Services.PriceCalculation
{
	[Service(ServiceType = typeof(ISponsorProgramDiscountCalculation))]
	public class SponsorProgramDiscountCalculation : ISponsorProgramDiscountCalculation
	{
		private readonly IDiscountSponsorProgramService _discountSponsorProgramService;
		public SponsorProgramDiscountCalculation(IDiscountSponsorProgramService discountSponsorProgramService)
		{
			_discountSponsorProgramService = discountSponsorProgramService;
		}
		public decimal? GetRate(SpotBooking booking)
		{
			if (booking.IsNormalBooking)
			{
				if (booking.HasSponsorProgram)
				{
					var discountCustomer = _discountSponsorProgramService.GetAll()
						.Where(d => d.ProgramId == booking.SponsorProgramId)
						.FirstOrDefault();
					if (discountCustomer != null)
					{
						return discountCustomer.Rate;
					}
				}
			}
			return 0;
		}
	}
}
