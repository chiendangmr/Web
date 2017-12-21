using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IPositionRateService : IService<PositionRate>
	{
		IQueryable<PositionRate> GetAllIncludeTimeBand();
		Task<bool> CheckExistAsync(PositionRate positionRate);
	}
}
