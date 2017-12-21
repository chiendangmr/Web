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
	[Service(ServiceType = typeof(IAnnexContractPartnerService))]
	public class AnnexContractPartnerService : Service<AnnexContractPartner, IAnnexContractPartnerRepository>, IAnnexContractPartnerService
	{
		private readonly ISpotBookingService _spotBookingService;
		public AnnexContractPartnerService(IAnnexContractPartnerRepository repository, ISpotBookingService spotBookingService) : base(repository)
		{
			_spotBookingService = spotBookingService;
		}

		public bool Exist(string code)
		{
			return _repository.List()
				.Any(s => s.AnnexContract.Code == code);
		}

		public IQueryable<AnnexContractPartner> GetAllAsync(Guid? customerId, int bookingTypeId)
		{
			return GetAll()
				.Where(a => (customerId != Guid.Empty && customerId != null) ? a.AnnexContract.CustomerId == customerId : true)
				.Where(a => bookingTypeId > 0 ? a.AnnexContract.BookingTypeId == bookingTypeId : true )
				;
		}

		public async Task<IQueryable<AnnexContractPartner>> GetAllInMonthAsync(int month, int year)
		{
			var spotBookings = await _spotBookingService.GetAll()
				.Where(s => s.Spot.BroadcastDate.Month == month && s.Spot.BroadcastDate.Year == year)
				.ToListAsync();
			var contracts = spotBookings.Where(s => s.IsNormalBooking)
				.GroupBy(s => s.AnnexContractAsset.AnnexContract.AnnexContractPartners)
				.Select( s => s.Key);
			return contracts.AsQueryable();
		}

		public async Task<AnnexContractPartner> GetByCodeAsync(string code)
		{
			return await _repository.List()
				.Where(s => s.AnnexContract.Code == code)
				.FirstOrDefaultAsync();
		}
		
	}
}
