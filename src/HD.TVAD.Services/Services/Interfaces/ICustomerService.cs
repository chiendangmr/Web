using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface ICustomerService : IService<Customer>
	{
		Task<bool> HasApprovedSpotAsync(Guid customerId);
	}
}
