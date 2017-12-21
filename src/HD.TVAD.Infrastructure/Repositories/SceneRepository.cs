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
    [Service(ServiceType = typeof(ISceneRepository))]
    public class SceneRepository : Repository<Scene>, ISceneRepository
    {
        public SceneRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Scene> Get(Guid id)
        {
            return _context.Query<Scene>()
                .Where(a => a.Id == id)                
                .Include(a => a.Origin)
                .Include(a=>a.SceneFiles);
        }
        public override IQueryable<Scene> List()
        {
            return _context.Query<Scene>()
                .Include(a => a.Origin)
                .Include(a => a.SceneFiles);
                
        }
    }
}
