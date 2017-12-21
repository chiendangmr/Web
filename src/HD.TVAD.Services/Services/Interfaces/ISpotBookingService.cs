using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface ISpotBookingService : IService<SpotBooking>
	{
		Task<int> Approve(SpotBooking spotBooking, bool approval);
		Task<int> CheckBookingCountByCustomerAsync(Guid customerId);
		Task<int> CheckBookingCountByAnnexContractAsync(Guid annexContractId);
	}
}
