﻿using System;
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
    [Service(ServiceType = typeof(IEvidenceRepository))]
    public class EvidenceRepository : Repository<Evidence>, IEvidenceRepository
    {
        public EvidenceRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Evidence> Get(Guid id)
        {
            return _context.Query<Evidence>()
                .Where(a => a.Id == id).Include(a=>a.Asset).Include(a=>a.Channel);

        }
        public override IQueryable<Evidence> List()
        {
            return _context.Query<Evidence>().Include(a => a.Asset).Include(a => a.Channel);
                
        }
    }    
}