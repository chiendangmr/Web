using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
	public interface IGetTypeService
	{
		IQueryable<BookingType> GetBookingTypes();
		IQueryable<CustomerType> GetCustomerTypes();
		IQueryable<TypeDetail> GetTypeDetails();
		Task<List<TypeDetail>> GetTypeDetailsByBookingTypeAsync(BookingTypeEnum bookingType);
		IQueryable<SponsorType> GetSponsorTypes();
		IQueryable<PriceType> GetPriceTypes(); 
		IQueryable<RetailType> GetRetailTypes();
		IQueryable<AnnexContractType> GetAnnexContractTypes();
	}
}
