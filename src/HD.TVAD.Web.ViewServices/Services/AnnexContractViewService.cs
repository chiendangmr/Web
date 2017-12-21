using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.ViewServices
{
	[Service(ServiceType = typeof(IAnnexContractViewService))]
	public class AnnexContractViewService : ViewService, IAnnexContractViewService
	{
		private readonly IAnnexContractService _annexContractService;
		private readonly IAnnexContractPartnerService _annexContractPartnerService;
		private readonly IGetTypeService _getTypeService;
		public AnnexContractViewService(IAnnexContractService annexContractService,
			IGetTypeService getTypeService,
			IAnnexContractPartnerService annexContractPartnerService)
		{
			_annexContractService = annexContractService;
			_getTypeService = getTypeService;
			_annexContractPartnerService = annexContractPartnerService;
		}

		public async Task<IEnumerable<SelectListItem>> GetAllAnnexContractSelectListItemAsync()
		{
			try
			{
				var annexContractSelectItems = await _annexContractService.GetAll()
					.OrderBy(c => c.Code)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Code
					}).ToListAsync();
				return annexContractSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetAnnexContractPartnerSelectListItemAsync()
		{
			try
			{
				var annexContractSelectItems = await _annexContractPartnerService.GetAll()
					.OrderBy(c => c.AnnexContract.Code)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.AnnexContract.Code
					}).ToListAsync();
				return annexContractSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetAnnexContractTypeListItemAsync()
		{
			var annexContractTypeSelectItems = await _getTypeService.GetAnnexContractTypes()
				.Select(c => new SelectListItem()
				{
					Value = c.Id.ToString(),
					Text = c.Name,
				}).ToListAsync();

			return annexContractTypeSelectItems;
		}

		public async Task<IEnumerable<SelectListItem>> GetBookingTypeSelectListItemAsync()
		{
			var bookingTypeSelectItems = await _getTypeService.GetBookingTypes()
				.Where(a => a.ParentId == (int)BookingTypeEnum.Contract_Sponsor || a.Id == (int)BookingTypeEnum.Contract_Booking)
				.Select(c => new SelectListItem()
				{
					Value = c.Id.ToString(),
					Text = c.Name,
				}).ToListAsync();
			return bookingTypeSelectItems;
		}

		public async Task<IEnumerable<SelectListItem>> GetCodeAndCustomerNameSelectListItemAsync()
		{
			try
			{
				var annexContractSelectItems = await _annexContractPartnerService.GetAll()
					.OrderBy(c => c.AnnexContract.Code)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = $"{a.AnnexContract.Code} - {a.AnnexContract.Customer.Name}" ,
					}).ToListAsync();
				return annexContractSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetCodeListAsync()
		{
			try
			{
				var annexContractSelectItems = await _annexContractPartnerService.GetAll()
					.OrderBy(c => c.AnnexContract.Code)
					.Select(a => new SelectListItem()
					{
						Text = a.AnnexContract.Code,
					}).ToListAsync();
				return annexContractSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetCodeListAsync(BookingTypeEnum bookingType)
		{
			try
			{
				var annexContractSelectItems = await _annexContractService.GetAll()
					.Where(a => a.BookingTypeId == (int)bookingType)
					.OrderBy(c => c.Code)
					.Select(a => new SelectListItem()
					{
						Text = a.Code,
					}).ToListAsync();
				return annexContractSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public Task<IEnumerable<SelectListItem>> GetOneSelectListItemAsync(Guid id)
		{
			try
			{
				var annexContract = _annexContractService.Get(id).FirstOrDefault();

				var list = new List<SelectListItem>();
				list.Add(new SelectListItem()
				{
					Value = annexContract.Id.ToString(),
					Text = annexContract.Code
				});
				var result = list.AsEnumerable();

				return Task.FromResult(result);

			}
			catch (Exception)
			{

				throw;
			}
		}

		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var annexContractSelectItems = await _annexContractService.GetAll()
					.OrderBy(c => c.Code)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Code
					}).ToListAsync();
				return annexContractSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IEnumerable<SelectListItem>> GetSomeSelectListItemAsync(IEnumerable<Guid> ids)
		{
			var annexContractSelectItems = await _annexContractService.GetAll()
				.Where(a => ids.Contains(a.Id))
				.Select(a => new SelectListItem()
				{
					Value = a.Id.ToString(),
					Text = a.Code
				}).ToListAsync();
			return annexContractSelectItems;
		}

		public async Task<IEnumerable<SelectListItem>> GetSponsorTypeSelectListItemAsync()
		{
			var sponsorTypeSelectItems = await _getTypeService.GetSponsorTypes()
				.Select(c => new SelectListItem()
			{
				Value = c.Id.ToString(),
				Text = c.Name,
			}).ToListAsync();
			return sponsorTypeSelectItems;
		}
	}
}
