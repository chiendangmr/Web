using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface ITimeBandSliceForTypeService : IService<TimeBandSliceForType>
	{
		Task<IList<TimeBand>> GetTimeBandsForTypeAsync(BookingTypeEnum bookingType);
		Task<IList<TimeBandSlice>> GetTimeBandSliceForType(Guid timeBandId,BookingTypeEnum bookingType);
	}
}
