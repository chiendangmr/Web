using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class ModuleViewModel
	{
		public int id { get; set; }
		
		public string ModuleName { get; set; }

		public string ModuleDescription { get; set; }

		public int? parentId { get; set; }

		public Guid ModulePermissionID { get; set; }

		public bool HasPermission { get; set; }
	}
}
