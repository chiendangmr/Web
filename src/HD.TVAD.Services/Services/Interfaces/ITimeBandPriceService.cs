using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Web.Services
{
    public interface ITimeBandPriceService : IService<TimeBandPrice>
	{
		decimal? GetRateOfBlock(Guid timeBandId,Guid spotBlockId);
	}
}
