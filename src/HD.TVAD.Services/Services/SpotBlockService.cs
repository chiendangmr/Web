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
	[Service(ServiceType = typeof(ISpotBlockService))]
	public class SpotBlockService : Service<SpotBlock, ISpotBlockRepository>, ISpotBlockService
	{
		public SpotBlockService(ISpotBlockRepository repository) : base(repository)
		{
		}

		public bool Exist(SpotBlock block)
		{
			return _repository.List()
				.Any(s => s.Duration == block.Duration);
		}
	}
}
