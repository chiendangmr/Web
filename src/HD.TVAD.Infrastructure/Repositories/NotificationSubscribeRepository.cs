using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(INotificationSubscribeRepository))]
	public class NotificationSubscribeRepository :  Repository<NotificationSubscribe>, INotificationSubscribeRepository
	{
		public NotificationSubscribeRepository(IDataContext context) : base(context)
		{
		}		
		public override IQueryable<NotificationSubscribe> Get(Guid id)
		{
			return _context.Query<NotificationSubscribe>()
				.Where(c => c.Id == id);
		}		

		public override IQueryable<NotificationSubscribe> List()
		{
			return _context.Query<NotificationSubscribe>()
			//	.Include(c => c.User);
			;

		}
	}
}
