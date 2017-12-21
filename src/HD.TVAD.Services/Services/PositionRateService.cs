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
	[Service(ServiceType = typeof(IPositionRateService))]
	public class PositionRateService : Service<PositionRate, IPositionRateRepository>, IPositionRateService
	{
		public PositionRateService(IPositionRateRepository repository) : base(repository)
		{
			_repository = repository;
		}

		public async Task<bool> CheckExistAsync(PositionRate positionRate)
		{
			if (positionRate.TimeBandId == null)
			{
				return await _repository.List()
					.AnyAsync(a => a.StartDate == positionRate.StartDate);
			}
			var positionRates = _repository.ListIncludeTimeBand().ToList();

			var result = positionRates.Any(a => a.StartDate == positionRate.StartDate 
											&& a.TimeBandId == positionRate.TimeBandId);

			return result;
		}

		public IQueryable<PositionRate> GetAllIncludeTimeBand()
		{
			return _repository.ListIncludeTimeBand();
		}
		
	}
}
