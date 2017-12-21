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
using HD.TVAD.ApplicationCore.Models;
using Dapper;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(ISpotRepository))]
	public class SpotRepository : Repository<Spot>, ISpotRepository
	{
		public SpotRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<Spot> Get(Guid id)
		{
			return _context.Query<Spot>()
				.Where(s => s.Id == id)
				.Include(a => a.TimeBandSlice)
				.ThenInclude(a => a.TimeBand)
				.ThenInclude(a => a.TimeBandBase).ThenInclude(a => a.Parent)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.PriceTypeDetail)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.Customer).ThenInclude(a => a.CustomerPartners)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorProgram)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.Content).ThenInclude(a => a.Producer)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.Content).ThenInclude(a => a.ProductGroup)
				.Include(a => a.SpotBookings).ThenInclude(a => a.SpotAssetByBookings).ThenInclude(s => s.SpotAsset)
				.Include(a => a.SpotAssets).ThenInclude(a => a.SpotAssetByBookings)
				.Include(a => a.SpotAssets).ThenInclude(a => a.SpotAssetByAssets).ThenInclude(t => t.Asset);
		}
		public Task<Spot> Get(Spot spot)
		{
			return _context.Query<Spot>()
				.Where(a => a.BroadcastDate == spot.BroadcastDate && a.TimeBandSliceId == spot.TimeBandSliceId)
				.FirstOrDefaultAsync();
		}

		public IQueryable<Spot> GetAllInclude()
		{
			return _context.Query<Spot>()
				.Include(a => a.TimeBandSlice).ThenInclude(a => a.TimeBandSliceDurations)
				.Include(a => a.TimeBandSlice).ThenInclude(a => a.TimeBandSliceDescriptions)
				.Include(a => a.TimeBandSlice).ThenInclude(a => a.TimeBand).ThenInclude(a => a.TimeBandDescriptions)
				.Include(a => a.TimeBandSlice).ThenInclude(a => a.TimeBand).ThenInclude(a => a.TimeBandTimes)
				.Include(a => a.TimeBandSlice).ThenInclude(a => a.TimeBand).ThenInclude(a => a.TimeBandDays)
				.Include(a => a.TimeBandSlice)
				.ThenInclude(a => a.TimeBand)
				.ThenInclude(a => a.TimeBandBase).ThenInclude(a => a.Parent)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.PriceTypeDetail)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.Customer).ThenInclude(a => a.CustomerPartners)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorProgram)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.Content).ThenInclude(a => a.Producer)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.Content).ThenInclude(a => a.ProductGroup)
				.Include(a => a.SpotBookings).ThenInclude(a => a.SpotAssetByBookings).ThenInclude(s => s.SpotAsset)
				.Include(a => a.SpotAssets).ThenInclude(a => a.SpotAssetByBookings)
				.Include(a => a.SpotAssets).ThenInclude(a => a.SpotAssetByAssets).ThenInclude(t => t.Asset);
		}

		public IList<ApprovalSpotViewModel> GetApprovalSpot(DateTime fromDate, DateTime? toDate, Guid? channelId, Guid? timeBandId, Guid? timeBandSliceId)
		{
			var __context = _context as DbContext;
			var conn = __context.Database.GetDbConnection();
			var result = conn.Query<ApprovalSpotViewModel>("SELECT *,[dbo].[fn_GetTextToSort](TimebandName) TimebandNameToSort FROM [Booking].[FN_GetSpotsBooking] (@fromDate, @toDate, @channelId, @timeBandId, @timeBandSliceId)" ,
				new {
					fromDate = fromDate,
					toDate = toDate ?? null,
					channelId = channelId ?? null,
					timeBandId = timeBandId ?? null,
					timeBandSliceId = timeBandSliceId ?? null
				}
				).ToList();

			return result;
		}

		public override IQueryable<Spot> List()
		{
			return _context.Query<Spot>()
				.Include(a => a.TimeBandSlice)
				.ThenInclude(a => a.TimeBand)
				.ThenInclude(a => a.TimeBandBase).ThenInclude(a => a.Parent)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.PriceTypeDetail)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.Customer).ThenInclude(a => a.CustomerPartners)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.AnnexContract).ThenInclude(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorProgram)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.Content).ThenInclude(a => a.Producer)
				.Include(a => a.SpotBookings).ThenInclude(a => a.AnnexContractAsset).ThenInclude(a => a.Content).ThenInclude(a => a.ProductGroup)
				.Include(a => a.SpotBookings).ThenInclude(a => a.SpotAssetByBookings).ThenInclude(s => s.SpotAsset)
				.Include(a => a.SpotAssets).ThenInclude(a => a.SpotAssetByBookings)
				.Include(a => a.SpotAssets).ThenInclude(a => a.SpotAssetByAssets).ThenInclude(t => t.Asset);
		}
	}
}
