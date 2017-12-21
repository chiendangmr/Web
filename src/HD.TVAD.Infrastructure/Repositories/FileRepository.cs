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
    [Service(ServiceType = typeof(IFileRepository))]
    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<File> Get(Guid id)
        {
            return _context.Query<File>()
                .Where(a => a.Id == id).Include(a => a.FileContents).Include(a => a.FileInStorages);

        }
        public override IQueryable<File> List()
        {
            return _context.Query<File>().Include(a => a.FileContents).Include(a => a.FileInStorages);

        }
    }
}
