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

    [Service(ServiceType = typeof(IContentTypeRepository))]
    public class ContentTypeRepository : Repository<ContentType>, IContentTypeRepository
    {
        public ContentTypeRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<ContentType> Get(Guid id)
        {
            return _context.Query<ContentType>()
                .Where(a => a.Id == id).Include(a => a.FileType);

        }
        public override IQueryable<ContentType> List()
        {
            return _context.Query<ContentType>().Include(a => a.FileType).OrderBy(a => a.Index);
        }
    }
}
