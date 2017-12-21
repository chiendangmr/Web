using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.Station;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HD.TVAD.Web.Services
{
	[HD.Station.Service(ServiceType = typeof(INotificationService))]
	public class NotificationService : Service<Notification, INotificationRepository>, INotificationService
	{
		private List<Notification> _notifications;
		private readonly INotificationSubscribeRepository _notificationSubscribeRepository;
		public NotificationService(INotificationRepository repository,
			INotificationSubscribeRepository notificationSubscribeRepository) : base(repository)
		{
			_notificationSubscribeRepository = notificationSubscribeRepository;

			_notifications = new List<Notification>();
			_notifications.Add(new Notification()
			{
				Action = NotifiActtion.Create,
				Content = "abc have new notification",
				CreateDate = DateTime.Now,
				Id = Guid.NewGuid(),
				Type = NotifiType.General,
				Module = NotifiModule.General,
				Link = "/s"
			});
		}
		public async Task<bool> CheckUpdateAsync(Guid userId)
		{
			return await CheckHasNewNotificationAsync(userId);
		}

		public async Task<List<Notification>> GetAllNewNotificationAsync(Guid userId)
		{
			if (await CheckHasNewNotificationAsync(userId))
			{
				var notification = await _repository.List().SelectMany(s => s.NotificationUsers)
					.Where(n => n.UserId == userId)
					.Where(n => n.IsRead == false)
					.Select(n => n.Notification)
					.ToListAsync();

			//	await SetFlagNewNotificationAsync(userId, false);

				return notification;
			}
			return await Task.FromResult(new List<Notification>());
		}

		public async Task MakeNotificationAsync(Notification notifi)
		{
			if (notifi == null)
			{
				throw new NullReferenceException(nameof(notifi));
			}
			var subscribes = await _notificationSubscribeRepository.List().ToListAsync();
			foreach (var subscribe in subscribes)
			{
				notifi.NotificationUsers.Add(new Notification_User() {
					IsRead = false,
					UserId = subscribe.Id,
				});
			}
			var result = await _repository.Create(notifi);
			await SetFlagNewNotificationAsync();
		}

		public async Task MarkAsReadAsync(Guid userId, Guid notificationId)
		{
			var notifi = _repository.Get(notificationId).FirstOrDefault();
			notifi.MarkAsRead(userId);
			var result = await _repository.Update(notifi);
		}

		public async Task MarkAsUnReadAsync(Guid userId, Guid notificationId)
		{
			var notifi = _repository.Get(notificationId).FirstOrDefault();
			notifi.MarkAsRead(userId);
			var result = await _repository.Update(notifi);
		}
		private async Task SetFlagNewNotificationAsync()
		{
			var subscribes = await _notificationSubscribeRepository.List().ToListAsync();
			foreach (var subscribe in subscribes)
			{
				subscribe.HasNewNotification = true;
				await _notificationSubscribeRepository.Update(subscribe);
			}
		}
		private async Task SetFlagNewNotificationAsync(Guid userId,bool hasNew)
		{
			var subscribe = await _notificationSubscribeRepository.Get(userId).FirstOrDefaultAsync();

				subscribe.HasNewNotification = hasNew;

				await _notificationSubscribeRepository.Update(subscribe);
		}
		private async Task<bool> CheckHasNewNotificationAsync(Guid userId)
		{
			var subcribe = await _notificationSubscribeRepository.Get(userId).FirstOrDefaultAsync();
			if (subcribe != null)
			{
				return subcribe.HasNewNotification;
			}
			return false;
		}

		public async Task MarkAsReadAllAsync(Guid userId)
		{
			await SetFlagNewNotificationAsync(userId, false);
		}
	}
}
