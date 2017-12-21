using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IRetailContractService : IService<RetailContract>
	{
		Task<RetailContract> GetByCodeAsync(string code);
		IQueryable<RetailContract> GetAllAsync(Guid? customerId);
	}
}