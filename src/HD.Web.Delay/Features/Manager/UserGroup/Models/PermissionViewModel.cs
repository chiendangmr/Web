using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class PermissionViewModel
	{
		public Guid id { get; set; }

		public string PermissionName { get; set; }

		public string DisplayName { get; set; }

		public Guid? parentId { get; set; }

		public bool HasPermission { get; set; }
	}
}
