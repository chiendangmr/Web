using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.Infrastructure.Data;
using HD.Station;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(ITimeBandBaseService))]
	public class TimeBandBaseService : Service<TimeBandBase, ITimeBandBaseRepository>, ITimeBandBaseService
	{
		public TimeBandBaseService(ITimeBandBaseRepository repository) : base(repository)
		{
		}
	}
}
