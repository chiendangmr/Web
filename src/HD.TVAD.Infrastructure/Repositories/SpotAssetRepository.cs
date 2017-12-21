using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(ISpotAssetRepository))]
	public class SpotAssetRepository : Repository<SpotAsset>, ISpotAssetRepository
	{
		public SpotAssetRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<SpotAsset> Get(Guid id)
		{
			return _context.Query<SpotAsset>()
				.Where(a => a.Id == id)
				.Include(s => s.SpotAssetByAssets).ThenInclude(s => s.Asset)
				.Include(s => s.SpotAssetByBookings)
				;
		}

		public override IQueryable<SpotAsset> List()
		{
			return _context.Query<SpotAsset>()
				.Include(s => s.SpotAssetByAssets).ThenInclude(s => s.Asset)
				.Include(s => s.SpotAssetByBookings)
				;

		}

	}
}
