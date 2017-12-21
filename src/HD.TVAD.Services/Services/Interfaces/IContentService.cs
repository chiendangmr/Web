using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
	public interface IContentService : IService<Content>
	{
		Task<Content> FindByCodeAsync(string code);
		Task<bool> ExistCodeAsync(string code);
		Task<bool> CheckAllowBookingAsync(SpotBooking spotBooking);
	}    
}
