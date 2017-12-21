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
	[Service(ServiceType = typeof(IAnnexContractAssetService))]
	public class AnnexContractAssetService : Service<AnnexContractAsset, IAnnexContractAssetRepository>, IAnnexContractAssetService
	{
		private readonly ISpotBookingService _spotBookingService;
		public AnnexContractAssetService(IAnnexContractAssetRepository repository, ISpotBookingService spotBookingService) : base(repository)
		{
			_spotBookingService = spotBookingService;
		}

		public async Task<bool> ExistAsync(Guid annexContractId, Guid assetId)
		{
			var result = await _repository.List()
				.AnyAsync(a => a.AnnexContractId == annexContractId && a.ContentId == assetId);
			return result;
		}

		public Task<bool> HasApprovedSpotAsync(Guid annexContractAssetId)
		{
			var spotBookings = _spotBookingService.GetAll()
				.Where(s => s.AnnexContractAssetId == annexContractAssetId);
			if (spotBookings.Any(s => s.SpotAssetByBookings != null))
			{
				return Task.FromResult(true);
			}
			return Task.FromResult(false);
		}
	}
}
