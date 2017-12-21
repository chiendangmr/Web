using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities.MediaAsset;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
    [Service(ServiceType = typeof(IMediaAssetRepository))]
    public class MediaAssetRepository : Repository<MediaAsset>, IMediaAssetRepository
    {
        public MediaAssetRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<MediaAsset> Get(Guid id)
        {
            return _context.Query<MediaAsset>()
                .Where(a => a.Id == id)
                .Include(a => a.Assets);
        }
        public override IQueryable<MediaAsset> List()
        {
            return _context.Query<MediaAsset>()
                .Include(a => a.Assets);
        }
    }
}
