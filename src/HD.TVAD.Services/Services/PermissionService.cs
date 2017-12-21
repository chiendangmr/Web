using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Security;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IPermissionService))]
	public class PermissionService : Service<Permission, IPermissionRepository>, IPermissionService
	{
		public PermissionService(IPermissionRepository repository) : base(repository)
		{
		}
	}
}
