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
	[Service(ServiceType = typeof(ICustomerService))]
	public class CustomerService : Service<Customer, ICustomerRepository>, ICustomerService
	{
		private readonly ISpotBookingService _spotBookingService;
		public CustomerService(ICustomerRepository repository, ISpotBookingService spotBookingService) : base(repository)
		{
			_spotBookingService = spotBookingService;
		}

		public Task<bool> HasApprovedSpotAsync(Guid customerId)
		{
			var spotBookings = _spotBookingService.GetAll()
				.Where(s => s.AnnexContractAsset.AnnexContract.CustomerId == customerId);
			if (spotBookings.Any(s => s.SpotAssetByBookings != null))
			{
				return Task.FromResult(true);
			}
			return Task.FromResult(false);
		}
	}
}
