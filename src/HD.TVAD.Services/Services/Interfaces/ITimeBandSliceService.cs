using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
	public interface ITimeBandSliceService : IService<TimeBandSlice>
	{
		string GetTimeBandSliceDescriptionByDate(Guid timeBandSliceId, DateTime broadcastDate);
		Task<int> GetMaxDurationAsync(Guid timeBandSliceId, DateTime broadcastDate);
		int GetMaxDuration(Guid timeBandSliceId, DateTime broadcastDate);
		int GetMaxDurationByBookingType(Guid timeBandSliceId, DateTime broadcastDate, BookingTypeEnum bookingType);
	}
}
