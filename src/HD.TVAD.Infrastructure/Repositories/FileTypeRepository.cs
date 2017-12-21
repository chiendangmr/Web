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
    [Service(ServiceType = typeof(IFileTypeRepository))]
    public class FileTypeRepository : RepositoryForIntId<FileType>, IFileTypeRepository
    {
        public FileTypeRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<FileType> Get(int id)
        {
            return _context.Query<FileType>()
                .Where(a => a.Id == id).Include(a => a.FileTypeExtensions);

        }
        public override IQueryable<FileType> List()
        {
            return _context.Query<FileType>().Include(a => a.FileTypeExtensions);
                
        }
    }    
}
