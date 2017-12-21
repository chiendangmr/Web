using HD.TVAD.Services.PriceCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	 public class DataSource<TViewModel> where TViewModel: class
	{
		public IList<TViewModel> Data { get; set; } = new List<TViewModel>();
	}
}
