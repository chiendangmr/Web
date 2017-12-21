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
	[Service(ServiceType = typeof(ISpotAssetService))]
	public class SpotAssetService : Service<SpotAsset, ISpotAssetRepository>, ISpotAssetService
	{
		private ISpotAssetByAssetRepository _spotAssetByAssetRepository;

		public SpotAssetService(ISpotAssetRepository repository
			, ISpotAssetByAssetRepository spotAssetByAssetRepository) : base(repository)
		{
			_spotAssetByAssetRepository = spotAssetByAssetRepository;
		}

		public bool ExistSpotAssetByAsset(Guid assetId)
		{
			return GetAllSpotAssetByAsset().Any(a => a.Id == assetId);
		}

		public IQueryable<SpotAssetByAsset> GetAllSpotAssetByAsset()
		{
			return _spotAssetByAssetRepository.List();
		}
	}
}
