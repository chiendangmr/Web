using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface ISpotService : IService<Spot>
	{
		Task<Spot> CheckExistSpot(Spot spot);
		Task<Spot> Get(Spot spot);
		bool Exist(Spot spot);
		IQueryable<Spot> GetAllInclude();
		IList<ApprovalSpotViewModel> GetApprovalSpot(DateTime fromDate, DateTime? toDate,
			Guid? channelId, Guid? TimeBandId,Guid? TimeBandSliceId );
	}
}
