using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(ISpotBookingRepository))]
	public class SpotBookingRepository : Repository<SpotBooking>, ISpotBookingRepository
	{
		public SpotBookingRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<SpotBooking> Get(Guid id)
		{
			return _context.Query<SpotBooking>()
				.Where( s => s.Id == id)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.Customer).ThenInclude(a => a.CustomerPartners)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.Content)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.PriceTypeDetail)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorProgram)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorType)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractType)
				.Include(s => s.Spot)
				.ThenInclude(s => s.TimeBandSlice)
				.ThenInclude(d => d.TimeBand)
				.ThenInclude(e => e.TimeBandBase)
				.Include(s => s.SpotAssetByBookings).ThenInclude(s => s.SpotAsset)
				;
		}

		public override IQueryable<SpotBooking> List()
		{
			return _context.Query<SpotBooking>()
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.Customer).ThenInclude(a => a.CustomerPartners)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.Content)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.PriceTypeDetail)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorProgram)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorType)
				.Include(s => s.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractType)
				.Include(s => s.Spot)
				.ThenInclude(s => s.TimeBandSlice)
				.ThenInclude(d => d.TimeBand)
				.ThenInclude(e => e.TimeBandBase)
				.Include(s => s.SpotAssetByBookings).ThenInclude(s => s.SpotAsset)
				;
			
		}
		
	}
}
