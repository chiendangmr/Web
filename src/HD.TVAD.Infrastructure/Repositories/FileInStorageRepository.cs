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
    [Service(ServiceType = typeof(IFileInStorageRepository))]
    public class FileInStorageRepository : Repository<FileInStorage>, IFileInStorageRepository
    {
        public FileInStorageRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<FileInStorage> Get(Guid id)
        {
            return _context.Query<FileInStorage>()
                .Where(a => a.Id == id).Include(a => a.FileDetails);

        }
        public override IQueryable<FileInStorage> List()
        {
            return _context.Query<FileInStorage>().Include(a => a.FileDetails);

        }
    }
}
