using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities.Storage;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
    [Service(ServiceType = typeof(IFileExtensionRepository))]
    public class FileExtensionRepository : Repository<FileExtension>, IFileExtensionRepository
    {
        public FileExtensionRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<FileExtension> Get(Guid id)
        {
            return _context.Query<FileExtension>()
                .Where(a => a.Id == id);

        }
        public override IQueryable<FileExtension> List()
        {
            return _context.Query<FileExtension>();
                
        }
    }    
}
