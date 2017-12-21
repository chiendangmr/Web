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
	[Service(ServiceType = typeof(ICustomerPartnerService))]
	public class CustomerPartnerService : Service<CustomerPartner, ICustomerPartnerRepository>, ICustomerPartnerService
	{
		public CustomerPartnerService(ICustomerPartnerRepository repository) : base(repository)
		{
		}

		public Task<bool> ExistCodeAsync(string code)
		{
			return _repository.List()
				.AnyAsync(s => s.Code == code);
		}
	}
}
