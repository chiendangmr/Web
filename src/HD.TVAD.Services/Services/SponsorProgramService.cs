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
	[Service(ServiceType = typeof(ISponsorProgramService))]
	public class SponsorProgramService : Service<SponsorProgram, ISponorProgramRepository>, ISponsorProgramService
	{
		public SponsorProgramService(ISponorProgramRepository repository) : base(repository)
		{
		}

		public Task<bool> ExistCode(string code)
		{
			return _repository.List()
				.AnyAsync(a => a.Code == code);
		}
	}
}
