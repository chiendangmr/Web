using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.Infrastructure.Data;
using HD.Station;
using HD.TVAD.ApplicationCore.Models;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(ISpotService))]
	public class SpotService : Service<Spot, ISpotRepository>, ISpotService
	{
		private ISpotRepository _spotRepository;
		public SpotService(ISpotRepository spotRepository): base(spotRepository)
		{

			_spotRepository = spotRepository;
		}		

		public Task<Spot> CheckExistSpot(Spot spot)
		{
			return _spotRepository.Get(spot);
		}

		public bool Exist(Spot spot)
		{
			return _spotRepository.List()
				.Any(s => s.BroadcastDate == spot.BroadcastDate
				&& s.TimeBandSliceId == spot.TimeBandSliceId);
		}
		public Task<Spot> Get(Spot spot)
		{
			return _spotRepository.Get(spot);
		}

		public IQueryable<Spot> GetAllInclude()
		{
			return _spotRepository.GetAllInclude();
		}

		public IList<ApprovalSpotViewModel> GetApprovalSpot(DateTime fromDate, DateTime? toDate, Guid? channelId, Guid? TimeBandId, Guid? TimeBandSliceId)
		{
			return _repository.GetApprovalSpot(fromDate, toDate, channelId, TimeBandId, TimeBandSliceId);
		}
	}
}
