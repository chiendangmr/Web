using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
	public interface INotificationService : IService<Notification>
	{
		Task<List<Notification>> GetAllNewNotificationAsync(Guid userId);
		Task MarkAsReadAsync(Guid userId, Guid notificationId);
		Task MarkAsUnReadAsync(Guid userId, Guid notificationId);
		Task<bool> CheckUpdateAsync(Guid userId);
		Task MarkAsReadAllAsync(Guid userId);
		Task MakeNotificationAsync(Notification notifi);
	}
}
