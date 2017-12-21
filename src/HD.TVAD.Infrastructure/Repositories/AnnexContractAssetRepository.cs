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
	[Service(ServiceType = typeof(IAnnexContractAssetRepository))]
	public class AnnexContractAssetRepository : Repository<AnnexContractAsset>, IAnnexContractAssetRepository
	{
		public AnnexContractAssetRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<AnnexContractAsset> Get(Guid id)
		{
			return _context.Query<AnnexContractAsset>()
				.Where( a=> a.Id == id)
				.Include(a => a.PriceTypeDetail)
				.Include(a => a.Content)
				.Include(a => a.AnnexContract).ThenInclude(a => a.Customer)
				.Include(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.SpotBookings)
			//	.ThenInclude( a=> a.SpotAssetByBookings)
				.Include(a => a.SpotBookings)
				.ThenInclude(b => b.Spot)
				.ThenInclude(c => c.TimeBandSlice)
				.ThenInclude(d => d.TimeBand)
				.ThenInclude(e => e.TimeBandBase);
		}

		public override IQueryable<AnnexContractAsset> List()
		{
			return _context.Query<AnnexContractAsset>()
				.Include(a => a.PriceTypeDetail)
				.Include(a => a.Content)
				.Include(a => a.AnnexContract).ThenInclude(a => a.Customer)
				.Include(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.SpotBookings)
			//	.ThenInclude(a => a.SpotAssetByBookings)
				.Include(a => a.SpotBookings)
				.ThenInclude(b => b.Spot)
				.ThenInclude(c => c.TimeBandSlice)
				.ThenInclude(d => d.TimeBand)
				.ThenInclude(e => e.TimeBandBase);			
		}
		
	}
}
