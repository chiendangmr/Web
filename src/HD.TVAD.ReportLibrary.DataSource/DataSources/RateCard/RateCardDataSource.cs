using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.RateCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HD.TVAD.ReportLibrary.RateCard
{
    public class RateCardDataSource : DataSource<RateCardViewModel>
    {
		public RateCardDataSource(ITimeBandPriceService timeBandPriceService)
		{
			Data = timeBandPriceService.GetAll().Select(t => new RateCardViewModel()
			{
				ChannelName = t.TimeBand.TimeBandBase.Parent.Name,
				Price = t.Price,
				SpotBlockDuration = t.SpotBlock.Duration,
				StartDate = t.StartDate,
				TimeBandName = t.TimeBand.TimeBandBase.Name
			}).ToList();
		}
    }
}
