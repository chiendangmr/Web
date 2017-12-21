using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(ISpotBookingService))]
	public class SpotBookingService : Service<SpotBooking, ISpotBookingRepository>, ISpotBookingService
	{
		public SpotBookingService(ISpotBookingRepository repository) : base(repository)
		{
		}

		public Task<int> Approve(SpotBooking spotBooking, bool approval)
		{
			throw new NotImplementedException();
		}

		public async Task<int> CheckBookingCountByAnnexContractAsync(Guid annexContractId)
		{
			var result = await _repository.List()
				.Where(r => r.AnnexContractAsset.AnnexContractId == annexContractId)
				.CountAsync();
			return result;
		}

		public async Task<int> CheckBookingCountByCustomerAsync(Guid customerId)
		{
			var result = await _repository.List()
				.Where(r => r.AnnexContractAsset.AnnexContract.CustomerId == customerId)
				.CountAsync();
			return result;
		}
	}
}
