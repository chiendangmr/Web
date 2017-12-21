using HD.TVAD.ApplicationCore.Entities.Booking;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.TVAD.Web.ViewServices
{
	public interface IAnnexContractViewService : IViewService
	{
		Task<IEnumerable<SelectListItem>> GetBookingTypeSelectListItemAsync();
		Task<IEnumerable<SelectListItem>> GetSponsorTypeSelectListItemAsync();
		Task<IEnumerable<SelectListItem>> GetCodeListAsync();
		Task<IEnumerable<SelectListItem>> GetCodeListAsync(BookingTypeEnum bookingType);
		Task<IEnumerable<SelectListItem>> GetCodeAndCustomerNameSelectListItemAsync();
		Task<IEnumerable<SelectListItem>> GetAllAnnexContractSelectListItemAsync();
		Task<IEnumerable<SelectListItem>> GetAnnexContractPartnerSelectListItemAsync();
		Task<IEnumerable<SelectListItem>> GetAnnexContractTypeListItemAsync();

		Task<IEnumerable<SelectListItem>> GetOneSelectListItemAsync(Guid id);
		Task<IEnumerable<SelectListItem>> GetSomeSelectListItemAsync(IEnumerable<Guid> ids);
	}
}
