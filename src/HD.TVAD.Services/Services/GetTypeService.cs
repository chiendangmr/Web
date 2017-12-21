using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Booking;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IGetTypeService))]
	public class GetTypeService : IGetTypeService
	{
		private IBookingTypeRepository _bookingTypeRepository;
		private IAnnexContractTypeRepository _annexContractTypeRepository;
		private ISponsorTypeRepository _sponsorTypeRepository;
		private ICustomerTypeRepository _customerTypeRepository;
		private ITypeDetailRepository _typeDetailRepository;
		private IPriceTypeRepository _priceTypeRepository;
		private IRetailTypeRepository _retailTypeRepository;
		public GetTypeService(
			IAnnexContractTypeRepository annexContractTypeRepository,
			IBookingTypeRepository bookingTypeRepository,
			ICustomerTypeRepository customerTypeRepository,
			ITypeDetailRepository typeDetailRepository,
			ISponsorTypeRepository sponsorTypeRepository,
			IPriceTypeRepository priceTypeRepository,
			IRetailTypeRepository retailTypeRepository)
		{
			_bookingTypeRepository = bookingTypeRepository;
			_customerTypeRepository = customerTypeRepository;
			_typeDetailRepository = typeDetailRepository;
			_sponsorTypeRepository = sponsorTypeRepository;
			_priceTypeRepository = priceTypeRepository;
			_retailTypeRepository = retailTypeRepository;
			_annexContractTypeRepository = annexContractTypeRepository;
		}

		public IQueryable<AnnexContractType> GetAnnexContractTypes()
		{
			return _annexContractTypeRepository.List();
		}

		public IQueryable<BookingType> GetBookingTypes()
		{
			return _bookingTypeRepository.List();
		}
		private BookingType GetParentBookingTypes(BookingTypeEnum bookingType)
		{
			return _bookingTypeRepository.List()
				.Where(b => b.Id == (int)bookingType)
				.FirstOrDefault()?
				.Parent;
		}
		public IQueryable<CustomerType> GetCustomerTypes()
		{
			return _customerTypeRepository.List();
		}

		public IQueryable<PriceType> GetPriceTypes()
		{
			return _priceTypeRepository.List();
		}

		public IQueryable<RetailType> GetRetailTypes()
		{
			return _retailTypeRepository.List();
		}

		public IQueryable<SponsorType> GetSponsorTypes()
		{
			return _sponsorTypeRepository.List();
		}

		public IQueryable<TypeDetail> GetTypeDetails()
		{
			return _typeDetailRepository.List();
		}

		public async Task<List<TypeDetail>> GetTypeDetailsByBookingTypeAsync(BookingTypeEnum bookingType)
		{
			var typeDetails = await GetTypeDetailsByBookingTypePrivateAsync(bookingType);
			if (typeDetails.Count > 0)
				return typeDetails;

			var parentBooking = GetParentBookingTypes(bookingType);
			if (parentBooking == null)
				throw new Exception($"Not found parent of {bookingType.ToString()}");

			var typeDetailsOfParent = await GetTypeDetailsByBookingTypePrivateAsync((BookingTypeEnum)parentBooking.Id);
			if (typeDetailsOfParent.Count > 0)
				return typeDetailsOfParent;

			var grandParentBooking = GetParentBookingTypes((BookingTypeEnum)parentBooking.Id);
			if (grandParentBooking == null)
				throw new Exception($"Not found grandParent of {bookingType.ToString()}");

			var typeDetailsOfGrandParent = await GetTypeDetailsByBookingTypePrivateAsync((BookingTypeEnum)grandParentBooking.Id);
			if (typeDetailsOfGrandParent.Count > 0)
				return typeDetailsOfGrandParent;

			throw new Exception($"Not support get typeDetails grandGrandparent of {bookingType.ToString()}");
		}
		private async Task<List<TypeDetail>> GetTypeDetailsByBookingTypePrivateAsync(BookingTypeEnum bookingType)
		{
			var typeDetails = await _typeDetailRepository.List()
				.Where(t => t.Type.BookingTypePriceTypes.Any(b => b.BookingTypeId == (int)bookingType))
				.OrderBy(t => t.Type.BookingTypePriceTypes.FirstOrDefault().Index)
				.ThenBy(t => t.Name)
				.ToListAsync();

			return typeDetails;
		}
	}

}
