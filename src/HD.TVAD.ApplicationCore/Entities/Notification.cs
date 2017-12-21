using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HD.TVAD.ApplicationCore.Entities
{
	public class Notification
	{
		public Notification()
		{
			NotificationUsers = new HashSet<Notification_User>();
		}
		public Notification(string content)
		{
			Content = content;
			CreateDate = DateTimeOffset.Now;
			NotificationUsers = new HashSet<Notification_User>();
		}
		public Guid Id { get; set; }
		public NotifiType Type { get; set; }
		public NotifiActtion Action { get; set; }
		public NotifiModule Module { get; set; }
		public string Content { get; set; }
		public string Link { get; set; }
		public DateTimeOffset CreateDate { get; set; }

		public virtual ICollection<Notification_User> NotificationUsers { get; set; }

		public void MarkAsRead(Guid userId)
		{
			var notification = NotificationUsers.Where(a => a.UserId == userId).FirstOrDefault(); ;
			if (notification != null)
			{
				notification.IsRead = true;
			}
			else
			{
				throw new NullReferenceException("notification");
			}
		}

		public void MarkAsUnRead(Guid userId)
		{
			var notification = NotificationUsers.Where(a => a.UserId == userId).FirstOrDefault(); ;
			if (notification != null)
			{
				notification.IsRead = false;
			}
			else
			{
				throw new NullReferenceException("notification");
			}
		}
	}

	public enum NotifiModule
	{
		[Display(Name = "General")]
		General = 0,
		[Display(Name = "System")]
		System = 1,
		[Display(Name = "User Manager")]
		UserManager = 2,
		[Display(Name = "Group Manager")]
		GroupManager = 3,
		[Display(Name = "Spot Block")]
		SpotBlock = 4,
		[Display(Name = "Booking")]
		Booking = 5,
	}

	public enum NotifiActtion
	{
		None = 0,
		Create = 1,
		Edit = 2,
		Delete = 3,
		Book = 4,
		Upload = 5,
		Download = 6,
		Login = 7,
		Logoff = 8,		
	}

	public enum NotifiType
	{
		None = 0,
		General = 1,
		Information = 2,
		Warning = 3,
		Error = 4,
		Critical = 5,
	}
}