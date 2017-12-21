using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class ChartDataSet
	{		
		public string label { get; set; }
		public IEnumerable<decimal> data { get; set; }
		public string backgroundColor { get; set; }
	}
}
