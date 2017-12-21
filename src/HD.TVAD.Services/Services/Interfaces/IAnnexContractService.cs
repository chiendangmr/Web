using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IAnnexContractService : IService<AnnexContract>
	{
		Task<AnnexContract> GetByCodeAsync(string code);
		IQueryable<AnnexContract> GetAllAsync(Guid? customerId);
		Task<BookingTypeEnum> GetBookingTypeAsync(Guid annexContractId);
		Task<bool> HasApprovedSpotAsync(Guid annexContractId);
		Task<bool> ExistCodeAsync(string code);
	}
}
