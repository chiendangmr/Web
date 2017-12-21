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
	[Service(ServiceType = typeof(IProducerViewService))]
	public class ProducerViewService : ViewService, IProducerViewService
	{
		private readonly IProducerService _producerService;
		public ProducerViewService(IProducerService producerService)
		{
			_producerService = producerService;
		}
		public override async Task<IEnumerable<SelectListItem>> GetSelectListItemAsync()
		{
			try
			{
				var producerSelectItems = await _producerService.GetAll()
					.OrderBy(c => c.Name)
					.Select(a => new SelectListItem()
					{
						Value = a.Id.ToString(),
						Text = a.Name
					}).ToListAsync();
				return producerSelectItems;

			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
