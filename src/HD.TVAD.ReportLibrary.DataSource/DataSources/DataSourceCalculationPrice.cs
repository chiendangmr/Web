using HD.TVAD.Services.PriceCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	 public class DataSourceCalculationPrice<TViewModel> : DataSource<TViewModel> where TViewModel: class
	{
		protected readonly IPriceCalculationService _priceCalculationService;
		public DataSourceCalculationPrice(IPriceCalculationService priceCalculationService)
		{
			_priceCalculationService = priceCalculationService;
		}
	}
}
