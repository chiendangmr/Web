using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities.Storage;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;


namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IFileExtensionService))]
	public class FileExtensionService : Service<FileExtension, IFileExtensionRepository>, IFileExtensionService
    {
		public FileExtensionService(IFileExtensionRepository repository) : base(repository)
		{
		}
	}    
}
