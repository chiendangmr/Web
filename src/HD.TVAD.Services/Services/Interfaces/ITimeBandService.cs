using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface ITimeBandService : IService<TimeBand>
    {
		bool Exist(TimeBand TimeBand);
		string GetTimeBandDescriptionByDate(Guid timeBandId,DateTime date);
		Task<List<TimeBand>> GetAllTimeBandByChannelIdAsync(Guid channelId);
		/// <summary>
		/// Before 12:00 PM
		/// </summary>
		/// <param name="broarcastDate"></param>
		/// <returns></returns>
		Task<List<TimeBand>> GetAllTimeBandOfDayPart1Async(DateTime broarcastDate);
		/// <summary>
		/// After 12:00 PM
		/// </summary>
		/// <param name="broarcastDate"></param>
		/// <returns></returns>
		Task<List<TimeBand>> GetAllTimeBandOfDayPart2Async(DateTime broarcastDate);
	}
}
