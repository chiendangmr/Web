using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ApplicationCore.Repositories
{
    public interface ISpotRepository : IRepository<Spot>
    {
		Task<Spot> Get(Spot spot);
		IQueryable<Spot> GetAllInclude();
		IList<ApprovalSpotViewModel> GetApprovalSpot(DateTime fromDate, DateTime? toDate,
			Guid? channelId, Guid? TimeBandId, Guid? TimeBandSliceId);
	}
}
