using HD.TVAD.ApplicationCore.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ApplicationCore.Entities
{
	public class Notification_User
	{
		public Guid UserId { get; set; }
		public Guid NotificationId { get; set; }
		public bool IsRead { get; set; }

		public virtual User User { get; set; }
		public virtual Notification Notification { get; set; }
	}	
}