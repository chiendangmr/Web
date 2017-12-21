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
    [Service(ServiceType = typeof(IMimeTypeRepository))]
    public class MimeTypeRepository : Repository<MimeType>, IMimeTypeRepository
    {
        public MimeTypeRepository(IDataContext context) : base(context)
        {
        }

        public IQueryable<MimeType> Get(string id)
        {
            return _context.Query<MimeType>()
                .Where(a => a.InternetMediaType == id)
                .Include(a => a.Assets).Include(a => a.AssetLocators);



        }
        public override IQueryable<MimeType> List()
        {
            return _context.Query<MimeType>()
                .Include(a => a.Assets).Include(a => a.AssetLocators);
        }
    }
}
