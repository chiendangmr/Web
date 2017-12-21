using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.Customer;
using HD.TVAD.ReportLibrary.SponsorProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HD.TVAD.ReportLibrary
{
    public class SponsorProgramDataSource : DataSource<SponsorProgramViewModel>
    {
		public SponsorProgramDataSource(ISponsorProgramService sponorProgramService)
		{
			Data = sponorProgramService.GetAll()
				.OrderBy(s => s.Code)
				.Select(c => new SponsorProgramViewModel()
			{
				Code = c.Code,
				Name = c.Name
			}).ToList();
		}
    }
}
