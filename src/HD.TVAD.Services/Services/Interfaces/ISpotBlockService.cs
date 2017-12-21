using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.Web.Services
{
	public interface ISpotBlockService : IService<SpotBlock>
	{
		bool Exist(SpotBlock block);
	}
}
