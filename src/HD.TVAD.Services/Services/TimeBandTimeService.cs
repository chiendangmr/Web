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
	[Service(ServiceType = typeof(ITimeBandTimeService))]
	public class TimeBandTimeService : Service<TimeBandTime, ITimeBandTimeRepository>, ITimeBandTimeService
	{
		public TimeBandTimeService(ITimeBandTimeRepository repository) : base(repository)
		{
		}
	}
}
