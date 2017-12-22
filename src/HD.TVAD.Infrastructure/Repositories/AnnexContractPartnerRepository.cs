﻿using System;
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
	[Service(ServiceType = typeof(IAnnexContractPartnerRepository))]
	public class AnnexContractPartnerRepository : Repository<AnnexContractPartner>, IAnnexContractPartnerRepository
	{
		public AnnexContractPartnerRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<AnnexContractPartner> Get(Guid id)
		{
			return _context.Query<AnnexContractPartner>()
				.Where( a=> a.Id == id)
				.Include(a => a.AnnexContract).ThenInclude(a => a.Customer)
				.Include(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractType)
				.Include(a => a.SponsorProgram)
				.Include(a => a.SponsorType)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractAssets).ThenInclude(m => m.PriceTypeDetail)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractAssets).ThenInclude(b => b.Content);
		}

		public override IQueryable<AnnexContractPartner> List()
		{
			return _context.Query<AnnexContractPartner>()
				.Include(a => a.AnnexContract).ThenInclude(a => a.Customer)
				.Include(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractType)
				.Include(a => a.SponsorProgram)
				.Include(a => a.SponsorType)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractAssets).ThenInclude(m => m.PriceTypeDetail)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractAssets).ThenInclude(b => b.Content);

		}
		
	}
}