using HD.Station;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.ViewServices
{
	[Service(ServiceType = typeof(IContentTypeViewService))]
	public class ContentTypeViewService : ViewService, IContentTypeViewService
	{
		private readonly IContentTypeService _contentTypeService;
		private readonly IFileTypeService _fileTypeService;
		public ContentTypeViewService(IContentTypeService contentTypeService,
			IFileTypeService fileTypeService)
		{
			_contentTypeService = contentTypeService;
			_fileTypeService = fileTypeService;
		}

		public async Task<IEnumerable<SelectListItem>> GetFileTypeSelectListItemAsync()
		{
			var fileTypeSelectItems = await _fileTypeService.GetAll()
				.Select(a => new SelectListItem()
				{
					Value = a.Id.ToString(),
					Text = a.Name
				}).ToListAsync();
			return fileTypeSelectItems;
		}

		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var contentTypeSelectItems = await _contentTypeService.GetAll()
					.OrderBy(c => c.Name)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Name
					}).ToListAsync();
				return contentTypeSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
