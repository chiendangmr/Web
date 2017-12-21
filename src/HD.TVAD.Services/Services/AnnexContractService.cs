using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Booking;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IAnnexContractService))]
	public class AnnexContractService : Service<AnnexContract, IAnnexContractRepository>, IAnnexContractService
	{
		private readonly ISpotBookingService _spotBookingService;
		public AnnexContractService(IAnnexContractRepository repository, ISpotBookingService spotBookingService) : base(repository)
		{
			_spotBookingService = spotBookingService;
		}

		public async Task<bool> ExistCodeAsync(string code)
		{
			return await _repository.List()
				.AnyAsync(s => s.Code == code);
		}

		public IQueryable<AnnexContract> GetAllAsync(Guid? customerId)
		{
			return GetAll()
				.Where(a => (customerId != Guid.Empty) ? a.CustomerId == customerId : true)
				.Where(a => a.AnnexContractPartners != null);
		}

		public async Task<BookingTypeEnum> GetBookingTypeAsync(Guid annexContractId)
		{
			var annexContract = await _repository.Get(annexContractId).FirstOrDefaultAsync();
			if (annexContract != null)
			{
				var bookingType = (BookingTypeEnum)annexContract.BookingTypeId;
				return bookingType;
			}
			else
			{
				throw new NullReferenceException();
			}
		}

		public async Task<AnnexContract> GetByCodeAsync(string code)
		{
			return await _repository.List()
				.Where(s => s.Code == code)
				.FirstOrDefaultAsync();
		}

		public Task<bool> HasApprovedSpotAsync(Guid annexContractId)
		{
			var spotBookings = _spotBookingService.GetAll()
				.Where(s => s.AnnexContractAsset.AnnexContractId == annexContractId);
			if (spotBookings.Any(s => s.SpotAssetByBookings != null))
			{
				return Task.FromResult(true);
			}
			return Task.FromResult(false);
		}
	}
}
