using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;


namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IFileDetailService))]
	public class FileDetailService : Service<FileDetail, IFileDetailRepository>, IFileDetailService
    {
		public FileDetailService(IFileDetailRepository repository) : base(repository)
		{
		}
	}    
}
