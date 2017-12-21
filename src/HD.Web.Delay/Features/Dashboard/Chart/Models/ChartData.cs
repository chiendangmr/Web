using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class ChartData
	{		
		public IEnumerable<string> labels { get; set; }
		public IEnumerable<ChartDataSet> datasets { get; set; }
	}
}
