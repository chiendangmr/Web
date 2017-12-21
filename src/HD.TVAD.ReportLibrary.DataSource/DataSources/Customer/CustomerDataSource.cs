using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HD.TVAD.ReportLibrary.Customer
{
    public class CustomerDataSource: DataSource<CustomerViewModel>
    {
		public CustomerDataSource(ICustomerService customerService)
		{
			Data = customerService.GetAll()
				.Where(c => c.CustomerPartners != null)
				.OrderBy(s => s.CustomerPartners.Code)
				.Select(c => new CustomerViewModel()
			{
				CustomerCode = c.CustomerPartners.Code,
				CustomerName = c.Name
			}).ToList();
		}
    }
}
