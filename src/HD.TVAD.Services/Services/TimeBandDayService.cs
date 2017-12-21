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
	[Service(ServiceType = typeof(ITimeBandDayService))]
	public class TimeBandDayService : Service<TimeBandDay, ITimeBandDayRepository>, ITimeBandDayService
	{
		public TimeBandDayService(ITimeBandDayRepository repository) : base(repository)
		{
		}
	}
}
