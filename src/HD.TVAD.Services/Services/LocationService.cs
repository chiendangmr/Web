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
	[Service(ServiceType = typeof(ILocationService))]
	public class LocationService : Service<Location, ILocationRepository>, ILocationService
    {
		public LocationService(ILocationRepository repository) : base(repository)
		{
		}
	}    
}
