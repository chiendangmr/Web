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
    [Service(ServiceType = typeof(IFileDetailRepository))]
    public class FileDetailRepository : Repository<FileDetail>, IFileDetailRepository
    {
        public FileDetailRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<FileDetail> Get(Guid id)
        {
            return _context.Query<FileDetail>()
                .Where(a => a.Id == id).Include(a=>a.FileDetailLocations);

        }
        public override IQueryable<FileDetail> List()
        {
            return _context.Query<FileDetail>().Include(a => a.FileDetailLocations);
                
        }
    }    
}
