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
    [Service(ServiceType = typeof(INotificationRepository))]
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Notification> Get(Guid id)
        {
            return _context.Query<Notification>()
                .Where(a => a.Id == id)
				.Include(n => n.NotificationUsers)
				.ThenInclude(n => n.User);

        }
        public override IQueryable<Notification> List()
        {
            return _context.Query<Notification>()
				.Include(n => n.NotificationUsers)
				.ThenInclude(n => n.User);
        }
    }    
}
