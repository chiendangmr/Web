using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(ITimeBandPriceService))]
	public class TimeBandPriceService : Service<TimeBandPrice, ITimeBandPriceRepository>, ITimeBandPriceService
	{
		public TimeBandPriceService(ITimeBandPriceRepository repository) : base(repository)
		{
		}

		public decimal? GetRateOfBlock(Guid timeBandId, Guid spotBlockId)
		{
			var timeBandPrice = _repository.List()
				.Where(s => s.SpotBlockId == spotBlockId && s.TimeBandId == timeBandId)
				.FirstOrDefault();
			if (timeBandPrice != null)
			{
				return timeBandPrice.Price;
			}
			else
			{
				return 0;
			}
		}
	}
}
