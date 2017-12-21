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
	[Service(ServiceType = typeof(IRetailContractService))]
	public class RetailContractService : Service<RetailContract, IRetailContractRepository>, IRetailContractService
	{
		public RetailContractService(IRetailContractRepository repository) : base(repository)
		{
		}

		public IQueryable<RetailContract> GetAllAsync(Guid? customerId)
		{
			return GetAll()
				.Where(a => (customerId != Guid.Empty) ? a.AnnexContract.CustomerId == customerId : true);
		}

		public async Task<RetailContract> GetByCodeAsync(string code)
		{
			return await _repository.List()
				.Where(s => s.AnnexContract.Code == code)
				.FirstOrDefaultAsync();
		}
		
	}
}
