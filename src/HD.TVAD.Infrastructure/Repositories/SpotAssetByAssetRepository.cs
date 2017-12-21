using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(ISpotAssetByAssetRepository))]
	public class SpotAssetByAssetRepository : Repository<SpotAssetByAsset>, ISpotAssetByAssetRepository
	{
		public SpotAssetByAssetRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<SpotAssetByAsset> Get(Guid id)
		{
			return _context.Query<SpotAssetByAsset>()
				.Where( a=> a.Id == id);
		}

		public override IQueryable<SpotAssetByAsset> List()
		{
			return _context.Query<SpotAssetByAsset>();
			
		}
		
	}
}
