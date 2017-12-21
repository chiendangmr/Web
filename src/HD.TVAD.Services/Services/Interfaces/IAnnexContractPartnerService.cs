using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IAnnexContractPartnerService : IService<AnnexContractPartner>
	{
		Task<AnnexContractPartner> GetByCodeAsync(string code);
		IQueryable<AnnexContractPartner> GetAllAsync(Guid? customerId,int bookingTypeId);
		Task<IQueryable<AnnexContractPartner>> GetAllInMonthAsync(int month, int year);
		bool Exist(string code);
	}
}