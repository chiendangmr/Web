using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class ChartViewModel
	{
		public ChartViewModel()
		{
			data = new Dictionary<string, ChartData>();
		}
		public IDictionary<string, ChartData> data { get; set; }
	}
}
