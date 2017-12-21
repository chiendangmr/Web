using HD.TVAD.ApplicationCore.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ApplicationCore.Entities
{
	public class NotificationSubscribe
	{
		public Guid Id { get; set; }
		public bool HasNewNotification { get; set; }
		public virtual User User { get; set; }
	}	
}